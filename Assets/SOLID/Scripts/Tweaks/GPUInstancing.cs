using UnityEngine;

namespace SOLID.Scripts.Tweaks
{
    /// <summary>
    /// Due to SRP batching won't use GPU instancing
    /// Break SRP batching for certain object with MaterialPropertyBlock
    /// this will force Unity to use the GPU instance (if checked)
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class GPUInstancing : MonoBehaviour
    {
        public void Awake()
        {
            var _materialPropertyBlock = new MaterialPropertyBlock();
            var _meshRenderer = GetComponent<MeshRenderer>();

            _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }
}
