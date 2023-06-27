using SOLID.Scripts.Interfaces;
using SOLID.Scripts.UI;
using UnityEngine;

namespace SOLID.Scripts.Objects
{
    public class BoxController : MiscObject, IDamageable
    {
        public int Health => health;
        public int MaxHealth => maxHealth;

        [Header("Settings")]
        [SerializeField, Range(0, 100)]
        private int health = 50;
        [SerializeField, Range(1, 100)]
        private int maxHealth = 50;

        [Space]
        [Header("UI")]
        [SerializeField]
        private HealthBar healthBar;

        public override void Initialization(Camera _mainCamera)
        {
            healthBar.Initialization(_mainCamera.transform, this);
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
            Destroy(gameObject);
        }
    }
}
