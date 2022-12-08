using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Service
{
    public class PauseService : IDisposable
    {
        private MessageSystem _messageSystem;
        private float _timeStartPause;
        private float _timeInPause;

        public PauseService(MessageSystem messageSystem)
        {
            _messageSystem = messageSystem;

            _messageSystem.UIEvents.OnPauseButtonClickEvent += OnPauseButtonClick;
            _messageSystem.UIEvents.OnContinueButtonClickEvent += OnContrinueButtonClick;
            _messageSystem.LevelEvents.OnLevelStated += OnLevelStarted;
        }

        private void OnLevelStarted()
        {
            _timeInPause = 0;
        }

        private void OnContrinueButtonClick()
        {
            Time.timeScale = 1;           
            _timeInPause = _timeInPause + (Time.realtimeSinceStartup - _timeStartPause);
        }

        private void OnPauseButtonClick()
        {
            Time.timeScale = 0;
            _timeStartPause = Time.realtimeSinceStartup;
        }

        public float GetTimeInPause()
        {
            return _timeInPause;
        }

        public void Dispose()
        {
            _messageSystem.UIEvents.OnPauseButtonClickEvent -= OnPauseButtonClick;
            _messageSystem.UIEvents.OnContinueButtonClickEvent -= OnContrinueButtonClick;
            _messageSystem.LevelEvents.OnLevelStated -= OnLevelStarted;
        }
    }
}
