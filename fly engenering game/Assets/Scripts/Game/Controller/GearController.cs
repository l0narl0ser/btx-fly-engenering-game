using Assets.Scripts.Game.Controller;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GearController : MonoBehaviour, IGameController
    {
        [SerializeField]
        private string _id;

        //private _inserted;

        public Vector2 _initedPosition;

        //Свойство
        public bool Inserted  { get; set; }

        private void Awake()
        {
            _initedPosition = transform.position;
        }
        public string GetId()
        {
            return _id;
        }

        public void ReturnToInitPostion()
        {
            transform.position = _initedPosition;
            Inserted = false;
        }


        //public void Insert(bool value)
        //{
        //    _inserted = false;
        //}

        //public bool GetInserted()
        //{
        //    return _inserted;
        //}
    }
}