using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Game.Data;
using Assets.Scripts.UI;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;

    [SerializeField] private InGameMenu _inGameMenu;

    [SerializeField] private PauseDialog _pauseDialog;

    [SerializeField] private WinDialog _winDialog;

    [SerializeField] private FinishGameDialog _finishGameDialog;

    private MessageSystem _messageSystem;

    private void Awake()
    {
        _messageSystem = Context.Instance.GetMessageSystem();
        _messageSystem.UIEvents.OnStartButtonClickEvent += OnGameplayStart;
        _messageSystem.UIEvents.OnPauseButtonClickEvent += OnPauseButtonClick;
        _messageSystem.UIEvents.OnContinueButtonClickEvent += OnContinueButtonClick;
        _messageSystem.LevelEvents.OnLevelFinished += OnLevelFinished;
        _messageSystem.LevelEvents.OnLastLevelReached += OnLastLevelReached;
    }

    private void Start()
    {
        ConfigureStartView();
    }

    private void ConfigureStartView()
    {
        _inGameMenu.gameObject.SetActive(false);
        _pauseDialog.gameObject.SetActive(false);
        _winDialog.gameObject.SetActive(false);
        _finishGameDialog.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _messageSystem.UIEvents.OnStartButtonClickEvent -= OnGameplayStart;
        _messageSystem.UIEvents.OnPauseButtonClickEvent -= OnPauseButtonClick;
        _messageSystem.UIEvents.OnContinueButtonClickEvent -= OnContinueButtonClick;
        _messageSystem.LevelEvents.OnLevelFinished -= OnLevelFinished;
        _messageSystem.LevelEvents.OnLastLevelReached -= OnLastLevelReached;
    }

    private void OnLastLevelReached()
    {
        _inGameMenu.gameObject.SetActive(false);
        _winDialog.gameObject.SetActive(false);
        _finishGameDialog.gameObject.SetActive(true);
    }

    private void OnLevelFinished(List<BalanceData> balanceDatas)
    {
        _inGameMenu.gameObject.SetActive(false);
        _winDialog.gameObject.SetActive(true);
    }

    private void OnGameplayStart()
    {
        _mainMenu.gameObject.SetActive(false);
        _winDialog.gameObject.SetActive(false);
        _finishGameDialog.gameObject.SetActive(false);
        _inGameMenu.gameObject.SetActive(true);
    }

    private void OnPauseButtonClick()
    {
        _inGameMenu.gameObject.SetActive(false);
        _pauseDialog.gameObject.SetActive(true);
    }

    private void OnContinueButtonClick()
    {
        _pauseDialog.gameObject.SetActive(false);
        _inGameMenu.gameObject.SetActive(true);
    }
}