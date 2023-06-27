using SOLID.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SOLID.Scripts.Inputs
{
    /// <summary>
    /// Simple input manager
    /// </summary>
    public class InputsReader : MonoBehaviour
    {
        public Vector2 Movement;
        public Vector2 Look;

        private PlayerController playerController;

        public void Initialization(PlayerController _playerController)
        {
            playerController = _playerController;
        }

        #region Input events

        public void MoveInput(Vector2 _newMoveDirection)
        {
            Movement = _newMoveDirection;
        }

        public void LookInput(Vector2 _newLookDirection)
        {
            Look = _newLookDirection;
        }

        public void FireInput()
        {
            playerController.Fire();
        }

        public void PistolInput()
        {
            playerController.ChangeWeapon(0);
        }

        public void SubMachineGunInput()
        {
            playerController.ChangeWeapon(1);
        }

        #region Actions

        //  SendMessage from PlayerInput component
        private void OnMovement(InputValue _input)
        {
            MoveInput(_input.Get<Vector2>());
        }

        //  SendMessage from PlayerInput component
        private void OnLook(InputValue _input)
        {
            LookInput(_input.Get<Vector2>());
        }

        //  SendMessage from PlayerInput component
        private void OnFire(InputValue _input)
        {
            FireInput();
        }

        //  SendMessage from PlayerInput component
        private void OnPistol(InputValue _input)
        {
            PistolInput();
        }

        //  SendMessage from PlayerInput component
        private void OnSubMachineGun(InputValue _input)
        {
            SubMachineGunInput();
        }

        #endregion

        #endregion

    }
}
