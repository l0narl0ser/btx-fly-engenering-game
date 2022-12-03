using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Context 
    {
        private static Context _intstance;

        private MessageSystem _messageSystem;
        private SnapshotManager _snapshotManager;
       
      
        public Context()
        {
            _messageSystem = new MessageSystem();
            _snapshotManager = new SnapshotManager();
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

    }
}