using UnityEngine;

namespace FlightAce.interfaces
{
    public interface IActorContext
    {
        IMovementInput MovementInput { get; }
        IWeaponInput WeaponInput { get; }
        Rigidbody2D Rigidbody2D { get;}
    }
}