using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Core;
using Assets.Scripts.Game.Service;

public class InGameMenu : MonoBehaviour
{
    private const float UpdateTimer = 1f;
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private TextMeshProUGUI _textTime;

    private TimeService _timeService;
    private float elipsedTime;

    private void Start()
    {
        _pauseButton.onClick.AddListener(OnClickButton);
        _timeService = Context.Instance.GetTimeService();
        
    }

    private void Update()
    {
        elipsedTime += Time.deltaTime;
        if (elipsedTime >= UpdateTimer)
        {
            elipsedTime = 0;
            int timeInLevel = Mathf.RoundToInt(_timeService.GetLevelTime());
            _textTime.text = timeInLevel.ToString();
        }
    }
    public void OnClickButton()
    {
        Context.Instance.GetMessageSystem().UIEvents.PauseButtonClickEvent();        
    }

}
