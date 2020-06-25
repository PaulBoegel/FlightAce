using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.player
{
    public class PlayerWeaponInput : IWeaponInput
    {
        public bool isFireing()
        {
            return Input.GetButton("Jump");
        }
    }
}