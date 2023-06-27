using SOLID.Scripts.Weapons;

namespace SOLID.Scripts.Interfaces
{
    public interface IWeaponsChanger
    {
        public Weapon ChangeWeapon(int _weaponIndex);
    }
}
