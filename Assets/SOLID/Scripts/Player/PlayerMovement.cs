using System;
using SOLID.Scripts.Interfaces;
using UnityEngine;

namespace SOLID.Scripts.Player
{
    [Serializable]
    public class PlayerMovement : IMove
    {
        public float Speed => speed;

        [SerializeField, Range(0, 10)]
        private float speed = 5;

        private Transform mainCameraTransform;
        private CharacterController characterController;

        public void Initialization(Transform _mainCameraTransform, CharacterController _characterController)
        {
            mainCameraTransform = _mainCameraTransform;
            characterController = _characterController;
        }

        public void Move(Vector3 _inputDirection)
        {
            //  Calculate the movement direction based on the camera's forward vector
            var _cameraDirection = Vector3.Scale(mainCameraTransform.transform.forward, new Vector3(1, 0, 1)).normalized;
            //  Calculate the _moveDirection using the camera's forward and right vectors
            var _moveDirection = _cameraDirection * _inputDirection.z + mainCameraTransform.transform.right * _inputDirection.x;
            //  Apply the _moveDirection multiplied by the move speed
            _moveDirection *= Speed;
            //  Set the Y component to 0 in _moveDirection
            _moveDirection = Vector3.Scale(_moveDirection, new Vector3(1, 0, 1));

            characterController.Move(Speed * Time.deltaTime * _moveDirection);
        }
    }
}
