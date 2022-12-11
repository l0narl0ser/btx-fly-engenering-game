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
        Context.Instance.GetMessageSystem().UIEvents.ContinueButtonClickEvent();
        gameObject.SetActive(false);
        
    }

    private void ExitGame()
    {
        Application.Instance.Exit();
    }

    private void RestartLevel()
    {
        Application.Instance.Restart();
    }
}
