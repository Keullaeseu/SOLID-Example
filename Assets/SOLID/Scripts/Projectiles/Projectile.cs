using System;
using UnityEngine;

namespace SOLID.Scripts.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public int Damage;

        [SerializeField]
        protected int ProjectileLifetime = 5;

        public virtual void OnCollisionEnter(Collision _collision)
        {
            throw new NotImplementedException();
        }
    }
}
