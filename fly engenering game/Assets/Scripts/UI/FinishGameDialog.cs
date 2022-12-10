using Assets.Scripts.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class FinishGameDialog : MonoBehaviour
    {
        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private Button _startNewGameButton;

        private MessageSystem _messageSystem;
        private SnapshotManager _snapshotManager;

        private void Awake()
        {
            _snapshotManager = Context.Inctance.GetSnapshotManager();
            _messageSystem = Context.Inctance.GetMessageSystem();
            _exitButton.onClick.AddListener(OnClickExitButton);
            _startNewGameButton.onClick.AddListener(OnClickStartNewGameButton);
        }

        private void OnClickStartNewGameButton()
        {
            _snapshotManager.Reset();
            Context.Inctance.GetMessageSystem().UIEvents.StartButtonClick();
        }

        private void OnClickExitButton()
        {
            Application.Inctance.Exit();
        }
    }

}