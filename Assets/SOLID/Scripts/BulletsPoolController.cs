using System.Collections.Generic;
using System.Linq;
using SOLID.Scripts.Projectiles;
using UnityEngine;

namespace SOLID.Scripts
{
    public class BulletsPoolController : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        [Space]
        [Header("Settings")]
        [SerializeField]
        private int poolSize = 100;

        private readonly List<Bullet> bulletsPool = new();
        private readonly BulletsPoolInstantiate bulletsPoolInstantiate = new();

        public void Initialization()
        {
            bulletsPoolInstantiate.InstantiatePool(bulletPrefab, poolSize, bulletsPool);
        }

        public Bullet GetFreeBullet()
        {
            //  Search for inactive bullet
            foreach (var _bullet in bulletsPool.Where(_bullet => !_bullet.gameObject.activeSelf))
            {
                return _bullet;
            }

            //  If all bullets in use, create a new one and add to bulletsPool
            return bulletsPoolInstantiate.InstantiateBullet(bulletPrefab, bulletsPool);
        }
    }

    public class BulletsPoolInstantiate
    {
        public void InstantiatePool(Bullet _bulletPrefab, int _poolSize, List<Bullet> _bulletsPool)
        {
            for (var _index = 0; _index < _poolSize; _index++)
            {
                InstantiateBullet(_bulletPrefab, _bulletsPool);
            }
        }

        public Bullet InstantiateBullet(Bullet _bulletPrefab, List<Bullet> _bulletsPool)
        {
            var _bulletNew = Object.Instantiate(_bulletPrefab);
            _bulletNew.gameObject.SetActive(false);
            _bulletsPool.Add(_bulletNew);
            return _bulletNew;
        }

    }
}
