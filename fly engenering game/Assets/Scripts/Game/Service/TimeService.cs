using Assets.Scripts.Core;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.Service
{
    public class TimeService : IDisposable
    {
        private MessageSystem _messageSystem;
        private PauseService _pauseService;
        
        private float _timeLevelStart;

        public TimeService(PauseService pauseService, MessageSystem messageSystem)
        {
            _pauseService = pauseService;
            _messageSystem = messageSystem;
            _messageSystem.LevelEvents.OnLevelStated += OnLevelStarted;
           
        }

        public void Dispose()
        {
            _messageSystem.LevelEvents.OnLevelStated -= OnLevelStarted;
        }

        private void OnLevelStarted()
        {
            //Взять время
            _timeLevelStart = Time.realtimeSinceStartup;
        }

        public float GetLevelTime()
        {
            return Time.realtimeSinceStartup - _timeLevelStart - _pauseService.GetTimeInPause();
        }
    }
}
