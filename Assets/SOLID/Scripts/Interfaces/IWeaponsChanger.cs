using SOLID.Scripts.Weapons;
using System.Collections.Generic;

namespace SOLID.Scripts.Interfaces
{
    public interface IWeaponsChanger
    {
        public List<Weapon> WeaponsList { get; }

        public Weapon RequestForChange(Weapon _currentWeapon, int _weaponIndex);

        public Weapon ChangeWeapon(int _weaponIndex);
    }
}
