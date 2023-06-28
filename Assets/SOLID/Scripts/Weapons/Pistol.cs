using SOLID.Scripts.Interfaces;
using UnityEngine;

namespace SOLID.Scripts.Weapons
{
    public class Pistol : Weapon, IFire
    {
        [SerializeField]
        private BulletsPoolController bulletsPoolController;

        public void Fire()
        {
            var _spawnedProjectile = bulletsPoolController.GetFreeBullet();
            _spawnedProjectile.StartBulletLifetime();

            var _projectileTransform = _spawnedProjectile.gameObject.transform;
            _projectileTransform.SetPositionAndRotation(ProjectileSpawnTransform.position, ProjectileSpawnTransform.rotation);
            _spawnedProjectile.gameObject.SetActive(true);

            _spawnedProjectile.GetComponent<Rigidbody>().AddForce(_spawnedProjectile.transform.up * ProjectileFireForce);
        }
    }
}
