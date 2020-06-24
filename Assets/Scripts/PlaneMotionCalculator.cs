using UnityEngine;

namespace FlightAce
{
    public class PlaneMotionCalculator
    {
        public Vector3 CalculateNewPosition(Vector3 inputV, Vector3 position, float speed, Vector2 boundries)
        {
            inputV = Time.deltaTime * speed * inputV;
            var newPosition = new Vector3(inputV.x + position.x, inputV.y + position.y, 0);

            if (newPosition.x > boundries.x || newPosition.x < -boundries.x)
                newPosition.x = position.x;
            
            if (newPosition.y > boundries.y || newPosition.y < -boundries.y)
                newPosition.y = position.y;

            return newPosition;
        }

        public Quaternion CalculateNewRotation(Vector3 inputV, Vector3 rotation, float speed, float angle)
        {
            var newRotation = Quaternion.identity;

            return newRotation;
        }
    }
}