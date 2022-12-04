using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Service
{
    public class TimeService : IDisposable
    {
        private MessageSystem _messageSystem;
        private float _timeLevelStart;

        public TimeService()
        {
            _messageSystem.LevelEvents.OnLevelStated += OnLevelStarted;
        }

        public void Dispose()
        {
            _messageSystem.LevelEvents.OnLevelStated -= OnLevelStarted;
        }

        private void OnLevelStarted()
        {
            //Взять время
        }

        public float GetLevelTime()
        {
            return Time.realtimeSinceStartup - _timeLevelStart;
        }
    }
}
