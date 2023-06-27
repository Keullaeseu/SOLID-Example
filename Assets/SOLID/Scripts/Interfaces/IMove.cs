using UnityEngine;

namespace SOLID.Scripts.Interfaces
{
    public interface IMove
    {
        public float Speed { get; }

        public void Move(Vector3 _inputDirection);
    }
}
