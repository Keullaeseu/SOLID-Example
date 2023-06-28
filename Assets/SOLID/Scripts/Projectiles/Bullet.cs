using SOLID.Scripts.Interfaces;
using UnityEngine;

namespace SOLID.Scripts.Projectiles
{
    public class Bullet : Projectile
    {
        public void StartBulletLifetime()
        {
            Invoke(nameof(DisableBullet), ProjectileLifetime);
        }

        public override void OnCollisionEnter(Collision _collision)
        {
            if (!_collision.gameObject.TryGetComponent(out IDamageable _damageableComponent))
                return;

            _damageableComponent.TakeDamage(Damage);
            gameObject.SetActive(false);
        }

        private void DisableBullet()
        {
            gameObject.SetActive(false);
        }
    }
}
