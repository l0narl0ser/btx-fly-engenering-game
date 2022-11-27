﻿using Assets.Scripts.Core;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class InputController : MonoBehaviour
    {
        private MessageSystem _messageSystem;

        private void Awake()
        {
            _messageSystem = Context.Inctance.GetMessageSystem();
        }
        public void Update()
        {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            if (Input.GetMouseButtonDown(0))
            {                
                _messageSystem.InputEvents.UserInput(Input.mousePosition);
            }          

#else
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                _messageSystem.InputEvents.UserInput(touch.position);
            }
#endif
        }



    }
}