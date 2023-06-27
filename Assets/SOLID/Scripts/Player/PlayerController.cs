using SOLID.Scripts.Inputs;
using SOLID.Scripts.Interfaces;
using SOLID.Scripts.UI;
using SOLID.Scripts.Weapons;
using UnityEngine;

namespace SOLID.Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour, IDamageable
    {
        public int Health => health;
        public int MaxHealth => maxHealth;

        [Header("Player Settings")]
        [SerializeField, Range(0, 100)]
        private int health = 100;
        [SerializeField, Range(1, 100)]
        private int maxHealth = 100;

        [Space]
        [SerializeField]
        private PlayerGravity gravity = new();
        [SerializeField]
        private PlayerRotation rotation = new();
        [SerializeField]
        private PlayerMovement movement = new();
        [Space]
        [SerializeField]
        private PlayerWeaponsChanger weaponsChanger = new();

        [Space]
        [Header("UI")]
        [SerializeField]
        private HealthBar healthBar;

        private InputsReader inputReader;
        private Weapon currentWeapon;

        public void Initialization(InputsReader _inputsReader, Camera _mainCamera)
        {
            var _characterController = GetComponent<CharacterController>();
            inputReader = _inputsReader;

            gravity.Initialization(_characterController);
            rotation.Initialization(_mainCamera.transform, gameObject.transform);
            movement.Initialization(_mainCamera.transform, _characterController);
            healthBar.Initialization(_mainCamera.transform, this);

            //  Set default weapon is pistol
            ChangeWeapon(0);
        }

        public void Update()
        {
            gravity.ApplyGravity();

            //  Vector2 == operator uses approximation so is not floating point error prone, and is cheaper than magnitude.
            if (inputReader.Movement == Vector2.zero)
                return;

            var _inputDirection = new Vector3(inputReader.Movement.x, 0, inputReader.Movement.y);

            rotation.Rotate(_inputDirection);
            movement.Move(_inputDirection);
        }

        #region Input Events

        public void ChangeWeapon(int _weaponIndex)
        {
            currentWeapon = weaponsChanger.RequestForChange(currentWeapon, _weaponIndex);
        }

        public void Fire()
        {
            if (currentWeapon.TryGetComponent(out IFire _fireComponent))
                _fireComponent.Fire();
        }

        #endregion

        public void TakeDamage(int _damage)
        {
            health -= _damage;

            if (health <= 0)
                Dead();

            healthBar.UpdateHealthBar();
        }

        public void Dead()
        {
            //  Refresh HP
            health = maxHealth;
        }
    }
}
