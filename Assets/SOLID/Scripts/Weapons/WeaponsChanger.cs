using System;
using SOLID.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID.Scripts.Weapons
{
    [Serializable]
    public class WeaponsChanger : IWeaponsChanger
    {
        public List<Weapon> WeaponsList => weaponsList;

        [SerializeField]
        private List<Weapon> weaponsList = new();

        public Weapon RequestForChange(Weapon _currentWeapon, int _weaponIndex)
        {
            if (_currentWeapon != null)
                _currentWeapon.gameObject.SetActive(false);

            _currentWeapon = ChangeWeapon(_weaponIndex);
            _currentWeapon.gameObject.SetActive(true);

            return _currentWeapon;
        }

        public Weapon ChangeWeapon(int _weaponIndex) => WeaponsList[_weaponIndex];
    }
}
