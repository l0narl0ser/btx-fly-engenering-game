using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Button _restartButton;

    [SerializeField]
    private Button _exitButton;

    private SnapshotManager _snapchotManager;

    private void Awake()
    {
        _snapchotManager = Context.Instance.GetSnapshotManager(); 
        _startButton.onClick.AddListener(OnStartButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        
    }

    private void OnExitButtonClick()
    {
        Application.Instance.Exit();
    }

    private void OnRestartButtonClick()
    {
        _snapchotManager.Reset();
        Context.Instance.GetMessageSystem().UIEvents.StartButtonClick();
    }

    private void OnStartButtonClick()
    {
        Context.Instance.GetMessageSystem().UIEvents.StartButtonClick();
        gameObject.SetActive(false);
    }
}
