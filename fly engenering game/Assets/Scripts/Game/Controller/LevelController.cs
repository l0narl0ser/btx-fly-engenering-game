using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Game.Data;
using UnityEngine;

namespace Assets.Scripts.Game.Controller
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<PortToGearAccordance> _portToGearAccordances = new List<PortToGearAccordance>();

        [SerializeField] private List<BalanceData> _levelBalance;

        [Serializable]
        private class PortToGearAccordance
        {
            [SerializeField] public PortController PortController;
            [SerializeField] public GearController GearController;
        }

        [SerializeField] private float _delayBeforeNewLevel = 0.5f;

        private MessageSystem _messageSystem;

        private void Awake()
        {
            _messageSystem = Context.Instance.GetMessageSystem();
            _messageSystem.LevelEvents.OnChangeLevelState += OnChangeLevelState;
        }

        private void OnDestroy()
        {
            _messageSystem.LevelEvents.OnChangeLevelState -= OnChangeLevelState;
        }

        private void OnChangeLevelState(Dictionary<GearController, PortController> portToGearAccordance)
        {

            bool loseCombination = false;
            foreach (PortToGearAccordance item in _portToGearAccordances)
            {
                if (!portToGearAccordance.ContainsKey(item.GearController))
                {
                    loseCombination = true;
                    continue;
                }
                PortController selectedPortController = portToGearAccordance[item.GearController];

                if (selectedPortController != item.PortController)
                {
                    loseCombination = true;
                }
                else
                {
                    item.GearController.StartRotationAnimation();
                }
            }

            if (loseCombination)
            {
                return;
            }
            
            PrepareStartNewLevel();
        }

        private void PrepareStartNewLevel()
        {
#if UNITY_EDITOR
            Debug.Log("You are wine");
#endif
            StartCoroutine(StartTimerCoroutine());
        }

        private IEnumerator StartTimerCoroutine()
        {
            yield return new WaitForSeconds(_delayBeforeNewLevel);
            _messageSystem.LevelEvents.FinishLevel(_levelBalance);
            Destroy(gameObject);
        }
    }
}