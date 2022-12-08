using Assets.Scripts.Game.Service;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Context
    {
        private static Context _intstance;

        private MessageSystem _messageSystem;
        private SnapshotManager _snapshotManager;
        private PauseService _pauseService;
        private TimeService _timeService;

        public Context()
        {
            _messageSystem = new MessageSystem();
            _snapshotManager = new SnapshotManager();
            _pauseService = new PauseService(_messageSystem);
            _timeService = new TimeService(_pauseService, _messageSystem);
        }

        public static Context Inctance
        {
            get
            {
                if (_intstance != null)
                {
                    return _intstance;
                }
                _intstance = new Context();
                return _intstance;
            }
        }
        public MessageSystem GetMessageSystem()
        {
            return _messageSystem;
        }

        public SnapshotManager GetSnapshotManager()
        {
            return _snapshotManager;
        }

        public TimeService GetTimeService()
        {
            return _timeService;
        }

        public PauseService GetPauseService()
        {
            return _pauseService;
        }
    }
}