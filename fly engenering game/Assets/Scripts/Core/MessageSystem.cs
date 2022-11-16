using Assets.Scripts.UI.Event;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MessageSystem 
    {
        private static MessageSystem _intstance;

        public readonly UIEvents UIEvents = new UIEvents();

        public static MessageSystem Inctance
        {
            get
            {
                if (_intstance != null)
                {
                    return _intstance;

                }
                _intstance = new MessageSystem();
                return _intstance;
            }
        }



    }
}