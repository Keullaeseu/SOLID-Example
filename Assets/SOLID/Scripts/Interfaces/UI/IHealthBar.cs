using UnityEngine.UI;

namespace SOLID.Scripts.Interfaces.UI
{
    public interface IHealthBar
    {
        public IHealth HealthComponent { get; }
        public Image HealthBarImage { get; }

        public void UpdateHealthBar();
    }
}
