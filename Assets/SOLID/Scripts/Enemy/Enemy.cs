using UnityEngine;

namespace SOLID.Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public virtual void Initialization(Camera _mainCamera)
        {
            throw new System.NotImplementedException();
        }
    }
}
