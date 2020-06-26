using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.AI
{
    public class AIMovementInput: IMovementInput
    {
        public float horizontalSpeed { private get; set; }
        public float verticalSpeed { private get; set; }
        public float amplitude { private get; set; }

        public AIMovementInput(float hori, float verti, float amp)
        {
            horizontalSpeed = hori;
            verticalSpeed = verti;
            amplitude = amp;
        }
        
        private AIMovementInput _movementInput;
        
        public Vector3 GetInputVector()
        {
            var newPos = new Vector3(x: horizontalSpeed,y:  Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude,z: 0);
            return newPos;
        }
    }
}