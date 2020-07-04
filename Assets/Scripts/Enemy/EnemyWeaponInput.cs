using System;
using System.Dynamic;
using System.Runtime.InteropServices.WindowsRuntime;
using FlightAce.interfaces;
using UnityEditor;
using UnityEngine;

namespace FlightAce.Enemy
{
    public class EnemyWeaponInput: IWeaponInput
    {
        private bool _isShooting;
        public bool isFireing()
        {
            return _isShooting;
        }

        public void setEnemyShooting()
        {
            if (_isShooting)
            {
                _isShooting = false;
                return;
            }

            _isShooting = true;
        }
    }
}