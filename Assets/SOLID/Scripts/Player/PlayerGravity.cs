using System;
using SOLID.Scripts.Interfaces;
using UnityEngine;

namespace SOLID.Scripts.Player
{
    [Serializable]
    public class PlayerGravity : IGravity
    {
        public float Gravity => gravity;

        [SerializeField, Range(-100, 0)]
        private float gravity = -15;

        private CharacterController characterController;

        public void Initialization(CharacterController _characterController)
        {
            characterController = _characterController;
        }

        public void ApplyGravity()
        {
            characterController.Move(new Vector3(0, Gravity, 0) * Time.deltaTime);
        }
    }
}
