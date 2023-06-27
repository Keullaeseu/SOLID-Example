using SOLID.Scripts.Interfaces;
using UnityEngine;

namespace SOLID.Scripts.Projectiles
{
    public class Bullet : Projectile
    {
        private void Start()
        {
            Destroy(gameObject, ProjectileLifetime);
        }

        public override void OnCollisionEnter(Collision _collision)
        {
            if (!_collision.gameObject.TryGetComponent(out IDamageable _damageableComponent))
                return;

            _damageableComponent.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
