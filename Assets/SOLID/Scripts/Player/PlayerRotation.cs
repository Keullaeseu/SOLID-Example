using System;
using SOLID.Scripts.Interfaces;
using UnityEngine;

namespace SOLID.Scripts.Player
{
    [Serializable]
    public class PlayerRotation : IRotate
    {
        public float RotationSmoothTime => rotationSmoothTime;

        [SerializeField, Range(0, 0.5f)]
        private float rotationSmoothTime = 0.05f;

        private Transform mainCameraTransform;
        private Transform playerTransform;

        private float rotationVelocity;

        public void Initialization(Transform _mainCameraTransform, Transform _playerTransform)
        {
            mainCameraTransform = _mainCameraTransform;
            playerTransform = _playerTransform;
        }

        public void Rotate(Vector3 _inputDirection)
        {
            //  Calculate _rotation
            var _targetRotation = Mathf.Atan2(_inputDirection.x, _inputDirection.z) * Mathf.Rad2Deg + mainCameraTransform.eulerAngles.y;
            var _rotation = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, _targetRotation, ref rotationVelocity, RotationSmoothTime);

            //  Rotate to face input _inputDirection relative to camera position
            playerTransform.rotation = Quaternion.Euler(0, _rotation, 0);
        }
    }
}
