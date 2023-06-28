using System;
using SOLID.Scripts.Interfaces;
using UnityEngine;

namespace SOLID.Scripts.UI
{
    [Serializable]
    public class HealthBarController
    {
        [SerializeField]
        private HealthBar healthBar;

        [Space]
        [Header("Settings")]
        [SerializeField, Tooltip("Show full heath bar?")]
        private bool showHealthPoint;

        private IHealth healthComponent;

        public void Initialization(Transform _mainCameraTransform, IHealth _healthComponent)
        {
            healthComponent = _healthComponent;
            healthBar.Initialization(_mainCameraTransform, _healthComponent);

            //  Disable health canvas
            if (!showHealthPoint)
                healthBar.gameObject.SetActive(false);
        }

        public void UpdateHealthBar()
        {
            if (!showHealthPoint && healthComponent.Health == healthComponent.MaxHealth)
            {
                if (healthBar.gameObject.activeSelf)
                    healthBar.gameObject.SetActive(false);
            }
            else
            {
                if (!healthBar.gameObject.activeSelf)
                    healthBar.gameObject.SetActive(true);
            }

            healthBar.UpdateHealthBar();
        }
    }
}
