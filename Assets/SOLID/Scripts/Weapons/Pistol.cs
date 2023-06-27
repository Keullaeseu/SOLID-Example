using SOLID.Scripts.Interfaces;

namespace SOLID.Scripts.Weapons
{
    public class Pistol : Weapon, IFire
    {
        public void Fire()
        {
            var _spawnedProjectile = Instantiate(ProjectileRigidbody, ProjectileSpawnTransform.position,
                ProjectileSpawnTransform.rotation);
            _spawnedProjectile.AddForce(_spawnedProjectile.transform.up * ProjectileFireForce);
        }
    }
}
