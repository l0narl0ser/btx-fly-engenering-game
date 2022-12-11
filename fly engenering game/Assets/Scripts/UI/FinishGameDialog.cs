using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class FinishGameDialog : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;

        [SerializeField] private Button _startNewGameButton;

        private MessageSystem _messageSystem;
        private SnapshotManager _snapshotManager;

        private void Awake()
        {
            _snapshotManager = Context.Instance.GetSnapshotManager();
            _messageSystem = Context.Instance.GetMessageSystem();
            _exitButton.onClick.AddListener(OnClickExitButton);
            _startNewGameButton.onClick.AddListener(OnClickStartNewGameButton);
        }

        private void OnClickStartNewGameButton()
        {
            _snapshotManager.Reset();
            Context.Instance.GetMessageSystem().UIEvents.StartButtonClick();
        }

        private void OnClickExitButton()
        {
            Application.Instance.Exit();
        }
    }
}