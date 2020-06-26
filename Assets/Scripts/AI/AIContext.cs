using System.Collections;
using System.Collections.Generic;
using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.AI
{
    public class AIContext : MonoBehaviour, IActorContext
    {
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float verticalSpeed;
        [SerializeField] private float amplitude;
        
        public IMovementInput MovementInput { get; private set; }
        public IWeaponInput WeaponInput { get; private set; }
        void Awake()
        {
            MovementInput = new AIMovementInput(horizontalSpeed, verticalSpeed, amplitude);
            WeaponInput = new AIWeaponInput();
         
        }

    }
 
}
