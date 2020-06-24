using UnityEngine;

namespace FlightAce.player
{
    public class PlayerInput : IInput
    {
        public Vector3 GetInputVector()
        {
            Vector3 inputV = Vector3.zero;
            inputV.x = Input.GetAxis("Horizontal");
            inputV.y = Input.GetAxis("Vertical");
            
            return inputV;
        }
    }
}
