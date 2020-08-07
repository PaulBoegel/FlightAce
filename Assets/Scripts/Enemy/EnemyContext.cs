using System;
using System.Collections;
using System.Collections.Generic;
using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.Enemy
{
    public class EnemyContext : MonoBehaviour, IActorContext
    {
        public static event Action OnEnemyDied;
        public IMovementInput MovementInput { get; private set; }
        public IWeaponInput WeaponInput { get; private set; }
        public IActualRole ActualRole { get; private set; }
        
        public bool basicEnemy;
        
        void Awake()
        {
            MovementInput = new EnemyMovementInput(basicEnemy);
            WeaponInput = new EnemyWeaponInput();
            ActualRole = new EnemyActualRole();
        }

        public void HandleDeath()
        {
            OnEnemyDied?.Invoke();
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
