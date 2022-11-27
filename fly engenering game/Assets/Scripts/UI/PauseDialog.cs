using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseDialog : MonoBehaviour
{
    [SerializeField]
    private Button _continueButton;

    [SerializeField]
    private Button _restartLevel;

    [SerializeField]
    private Button _exitGame;
    private void Awake()
    {
        _restartLevel.onClick.AddListener(RestartLevel);
        _continueButton.onClick.AddListener(ContinueGame);
        _exitGame.onClick.AddListener(ExitGame);
    }
    private void ContinueGame()
    {
        Context.Inctance.GetMessageSystem().UIEvents.ContinueButtonClickEvent();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void ExitGame()
    {
        Application.Inctance.Exit();
    }

    private void RestartLevel()
    {
        Application.Inctance.Restart();
    }
}