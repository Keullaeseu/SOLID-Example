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

            CancelInvoke();
            DisableBullet();
        }

        private void DisableBullet()
        {
            //  Reset velocity for next usage
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
