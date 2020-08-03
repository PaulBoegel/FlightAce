using System;
using FlightAce;
using FlightAce.interfaces;
using UnityEngine;
using Object = System.Object;

namespace FlightAce.player
{
    public class PlayerContext : MonoBehaviour, IActorContext
    {
        private int health = 105;
        private Sprite matDefault;
        private SpriteRenderer sr;

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

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            matDefault = sr.sprite;
          
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            sr.color = Color.white;
            sr.sprite = null;
            Destroy(collision.gameObject);
            health--;
            if(health <= 0)
            {
                DestroyPlayer();
            }
            else
            {
                Invoke("ResetMaterial", 0.1f);
            }
        }

        private void ResetMaterial()
        {
            sr.sprite = matDefault;
        }

        private void DestroyPlayer()
        {
            Destroy(gameObject);
        }
        
    }
}
