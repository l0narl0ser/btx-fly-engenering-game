using System;
using UnityEngine;

namespace Game.Controller
{
    public class InfinitelyRotateGearController : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 5;
        
        private Vector3 _vectorRotationSpeed;

        private void Awake()
        {
            _vectorRotationSpeed = new Vector3(0, 0, _rotationSpeed);
        }


        private void Update()
        {
            transform.eulerAngles += (_vectorRotationSpeed * Time.deltaTime);
        }
    }
}