using UnityEngine;

namespace Assets.Scripts.Game.Controller
{
    public class PortController : MonoBehaviour
    {
        [SerializeField] private Collider2D _portCollider;

        private bool _occupied;

        public bool Occupied
        {
            get => _occupied;
            set
            {
                //if(value == true)
                //{
                //    _occupied = true;
                //    _portCollider.enabled = false;
                //}
                //else
                //{
                //    _occupied = false;
                //    _portCollider.enabled = true;
                //}
                _occupied = value;
                _portCollider.enabled = !value;
            }
        }
    }
}