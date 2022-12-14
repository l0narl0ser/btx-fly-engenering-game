using Assets.Scripts.Game.Service;

namespace Assets.Scripts.Core
{
    public class Context
    {
        private static Context _intstance;

        private readonly MessageSystem _messageSystem;
        private readonly SnapshotManager _snapshotManager;
        private readonly PauseService _pauseService;
        private readonly TimeService _timeService;

        public Context()
        {
            _messageSystem = new MessageSystem();
            _snapshotManager = new SnapshotManager();
            _pauseService = new PauseService(_messageSystem);
            _timeService = new TimeService(_pauseService, _messageSystem);
        }

        public static Context Instance
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