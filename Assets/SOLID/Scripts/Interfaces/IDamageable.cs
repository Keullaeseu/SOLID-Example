namespace SOLID.Scripts.Interfaces
{
    public interface IDamageable : IHealth, IDeath
    {
        public void TakeDamage(int _damage);
    }
}
