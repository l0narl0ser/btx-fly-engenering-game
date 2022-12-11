using Assets.Scripts.Core;
using Assets.Scripts.Game.Data;
using Assets.Scripts.Game.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class WinDialog : MonoBehaviour
    {
        [SerializeField]
        private Button _contunueButton;
        [SerializeField]
        private List<GameObject> _stars;

        private MessageSystem _messageSystem;
        private TimeService _timeService;

        private void Awake()
        {
            _messageSystem = Context.Instance.GetMessageSystem();
            _timeService = Context.Instance.GetTimeService();
            _messageSystem.LevelEvents.OnLevelFinished += OnLevelFinished;
            _contunueButton.onClick.AddListener(OnClickContinueButton);

        }

        private void OnLevelFinished(List<BalanceData> balanceDatas)
        {
            float gameTime = _timeService.GetLevelTime();

            BalanceData balanceData = balanceDatas[balanceDatas.Count - 1]; ;

            foreach(BalanceData item in balanceDatas)
            {
                if(gameTime <= item.Seconds)
                {
                    balanceData = item;
                    break;
                }
            }
            TurnOnStartContainer(balanceData);

        }

        private void TurnOnStartContainer(BalanceData balanceData)
        {
            for (int i = 0; i < balanceData.CountStars; i++)
            {
                _stars[i].SetActive(true);
            }
        }

        private void OnClickContinueButton()
        {
            _messageSystem.UIEvents.StartButtonClick();
            for (int i = 0; i < _stars.Count; i++)
            {
                _stars[i].SetActive(false);
            }
        }

        private void OnDestroy()
        {
            _messageSystem.LevelEvents.OnLevelFinished -= OnLevelFinished;
        }
    }
}