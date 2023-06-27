using UnityEngine;

namespace SOLID.Scripts.Interfaces
{
    public interface IRotate
    {
        public float RotationSmoothTime { get; }

        public void Rotate(Vector3 _inputDirection);
    }
}
