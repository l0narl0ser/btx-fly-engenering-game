using Assets.Scripts.Core;
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

    private void Awake()
    {
        Context.Inctance.GetMessageSystem().UIEvents.OnStartButtonClickEvent += OnGameplayStart;
        Context.Inctance.GetMessageSystem().UIEvents.OnPauseButtonClickEvent += OnPauseButtonClick;
        Context.Inctance.GetMessageSystem().UIEvents.OnContinueButtonClickEvent += OnContinueButtonClick;
    }

    private void OnDestroy()
    {
        Context.Inctance.GetMessageSystem().UIEvents.OnStartButtonClickEvent -= OnGameplayStart;
        Context.Inctance.GetMessageSystem().UIEvents.OnPauseButtonClickEvent -= OnPauseButtonClick;
        Context.Inctance.GetMessageSystem().UIEvents.OnContinueButtonClickEvent -= OnContinueButtonClick;
    }

    private void OnGameplayStart()
    {
        _mainMenu.gameObject.SetActive(false);
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
