using System;
using FlightAce;
using FlightAce.interfaces;
using UnityEngine;
using Object = System.Object;

namespace FlightAce.player
{
    public class PlayerContext : MonoBehaviour, IActorContext
    {
        public IMovementInput MovementInput { get; private set; }
        public IWeaponInput WeaponInput { get; private set; }
        public IActualRole ActualRole { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            MovementInput = new PlayerMovementInput();
            WeaponInput = new PlayerWeaponInput();
            ActualRole = new PlayerActualRole();
            
        }
    }
}
