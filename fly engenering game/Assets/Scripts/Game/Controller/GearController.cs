using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GearController : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 5;

        private Vector2 _initedPosition;
        private bool _rotateEnabled;
        private Vector3 _vectorRotationSpeed;

        //Свойство
        public bool Inserted { get; set; }

        private void Awake()
        {
            _initedPosition = transform.position;
            _vectorRotationSpeed = new Vector3(0, 0, _rotationSpeed);
        }

        public void ReturnToInitPosition()
        {
            transform.position = _initedPosition;
            Inserted = false;
            StopRotationAnimation();
        }

        private void Update()
        {
            if (!_rotateEnabled)
            {
                return;
            }

            transform.eulerAngles += (_vectorRotationSpeed * Time.deltaTime);
        }

        public void StartRotationAnimation()
        {
            _rotateEnabled = true;
        }

        private void StopRotationAnimation()
        {
            _rotateEnabled = false;
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