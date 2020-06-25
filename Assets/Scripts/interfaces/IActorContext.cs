namespace FlightAce.interfaces
{
    public interface IActorContext
    {
        IMovementInput MovementInput { get; }
        IWeaponInput WeaponInput { get; }
    }
}