using UnityEngine;

namespace SOLID.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody ProjectileRigidbody;
        [SerializeField]
        protected Transform ProjectileSpawnTransform;

        [Space]
        [SerializeField]
        protected float ProjectileFireForce;
    }
}
