using System;
using FlightAce;
using FlightAce.interfaces;
using UnityEngine;

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

        private void OnCollisionEnter2D(Collision2D other)
        {
            Rigidbody2D.AddRelativeForce(Vector2.left * 100);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            Rigidbody2D.velocity = Vector2.zero;
        }
    }
}
