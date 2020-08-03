using System;
using System.Collections;
using System.Collections.Generic;
using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.Enemy
{
    public class EnemyContext : MonoBehaviour, IActorContext
    {
        private int health = 5;
        private Sprite matDefault;
        private SpriteRenderer sr;
            
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

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            matDefault = sr.sprite;
          
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if(collision.CompareTag("PlayerBullet"))
            {
                sr.color = Color.white;
                sr.sprite = null;
                Destroy(collision.gameObject);
                health--;
                if(health <= 0)
                {
                    DestroyEnemy();
                }
                else
                {
                    Invoke("ResetMaterial", 0.1f);
                }
            }
        }

        private void ResetMaterial()
        {
            sr.sprite = matDefault;
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }

        void OnBecameInvisible() {
            Destroy(gameObject);
        }

    }
 
}
