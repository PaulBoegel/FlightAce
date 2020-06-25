using FlightAce;
using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.player
{
    public class PlayerContext : MonoBehaviour, IActorContext
    {
        
        public IMovementInput MovementInput { get; private set; }
        public IWeaponInput WeaponInput { get; private set; }
        private void Awake()
        {
            MovementInput = new PlayerMovementInput();
            WeaponInput = new PlayerWeaponInput();
        }
    }
}
