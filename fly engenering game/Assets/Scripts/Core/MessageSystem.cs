using Assets.Scripts.Game;
using Assets.Scripts.Game.Events;
using Assets.Scripts.UI.Event;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MessageSystem 
    {     
        public readonly UIEvents UIEvents = new UIEvents();
        public readonly InputEvents InputEvents = new InputEvents();
        public readonly LevelEvents LevelEvents = new LevelEvents();
    }
}