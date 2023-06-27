using System;
using System.Collections.Generic;
using SOLID.Scripts.Interfaces;
using SOLID.Scripts.Weapons;
using UnityEngine;

namespace SOLID.Scripts.Enemy
{
    [Serializable]
    public class EnemyWeaponsChanger : IWeaponsChanger
    {
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
        public Weapon ChangeWeapon(int _weaponIndex) => weaponsList[_weaponIndex];
    }
}
