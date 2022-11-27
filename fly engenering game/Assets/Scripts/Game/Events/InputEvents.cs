using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class InputEvents 
    {
        public event Action<Vector2> OnUserInput; 
        
        public void UserInput(Vector2 vector2)
        {
            OnUserInput?.Invoke(vector2);
        }
    }

    
}