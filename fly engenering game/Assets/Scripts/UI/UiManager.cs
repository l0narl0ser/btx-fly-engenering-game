using Assets.Scripts.Core;
using Assets.Scripts.Game.Data;
using Assets.Scripts.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private MainMenu _mainMenu;

    [SerializeField]
    private InGameMenu _inGameMenu;

    [SerializeField]
    private PauseDialog _pauseDialog;

    [SerializeField]
    private WinDialog _winDialog;

    private MessageSystem _messageSystem;

    private void Awake()
    {
        _messageSystem = Context.Inctance.GetMessageSystem();
        _messageSystem.UIEvents.OnStartButtonClickEvent += OnGameplayStart;
        _messageSystem.UIEvents.OnPauseButtonClickEvent += OnPauseButtonClick;
        _messageSystem.UIEvents.OnContinueButtonClickEvent += OnContinueButtonClick;
        _messageSystem.LevelEvents.OnLevelFinished += OnLevelFinished;

        ConfigureStartView();

    }

    private void ConfigureStartView()
    {
        _inGameMenu.gameObject.SetActive(false);
        _pauseDialog.gameObject.SetActive(false);
        _winDialog.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _messageSystem.UIEvents.OnStartButtonClickEvent -= OnGameplayStart;
        _messageSystem.UIEvents.OnPauseButtonClickEvent -= OnPauseButtonClick;
        _messageSystem.UIEvents.OnContinueButtonClickEvent -= OnContinueButtonClick;
        _messageSystem.LevelEvents.OnLevelFinished -= OnLevelFinished;

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
