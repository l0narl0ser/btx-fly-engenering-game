using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GearController : MonoBehaviour
    {
        //private _inserted;

        public Vector2 _initedPosition;

        //Свойство
        public bool Inserted { get; set; }

        private void Awake()
        {
            _initedPosition = transform.position;
        }

        public void ReturnToInitPosition()
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