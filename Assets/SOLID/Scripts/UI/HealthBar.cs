using SOLID.Scripts.Interfaces;
using SOLID.Scripts.Interfaces.UI;
using UnityEngine;
using UnityEngine.UI;

namespace SOLID.Scripts.UI
{
    public class HealthBar : MonoBehaviour, IHealthBar
    {
        public IHealth HealthComponent { get; private set; }
        public Image HealthBarImage => healthBarImage;

        [SerializeField]
        private Image healthBarImage;

        private Transform mainCameraTransform;

        public void Initialization(Transform _mainCameraTransform, IHealth _healthComponent)
        {
            mainCameraTransform = _mainCameraTransform;

            HealthComponent = _healthComponent;
        }

        public void LateUpdate()
        {
            transform.LookAt(transform.position + mainCameraTransform.forward);
        }

        public void UpdateHealthBar()
        {
            HealthBarImage.fillAmount = (float)HealthComponent.Health / HealthComponent.MaxHealth;
        }
    }
}
