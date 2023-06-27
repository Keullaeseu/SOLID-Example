using System.Collections;
using SOLID.Scripts.Interfaces;
using SOLID.Scripts.Player;
using SOLID.Scripts.UI;
using SOLID.Scripts.Weapons;
using UnityEngine;

namespace SOLID.Scripts.Enemy
{
    public class EnemyRedCapsuleController : Enemy, IDamageable
    {
        public int Health => health;
        public int MaxHealth => maxHealth;

        [Header("Settings")]
        [SerializeField, Range(0, 100)]
        private int health = 100;
        [SerializeField, Range(1, 100)]
        private int maxHealth = 100;

        [SerializeField]
        private PlayerWeaponsChanger weaponsChanger = new();

        [Space]
        [Header("UI")]
        [SerializeField]
        private HealthBar healthBar;

        private Weapon currentWeapon;

        public override void Initialization(Camera _mainCamera)
        {
            healthBar.Initialization(_mainCamera.transform, this);

            //  Set default weapon is 0 slot
            ChangeWeapon(0);

            StartCoroutine(Fire());
        }

        public void ChangeWeapon(int _weaponIndex)
        {
            currentWeapon = weaponsChanger.RequestForChange(currentWeapon, _weaponIndex);
        }

        public IEnumerator Fire()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 3));

                if (currentWeapon.TryGetComponent(out IFire _fireComponent))
                    _fireComponent.Fire();
            }
        }

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
