using System;
using UnityEngine;

namespace FlightAce
{

    public class PlaneMotionCalculator
    {
        float lastYInput = 0;
        public Vector3 CalculateNewPosition(Vector3 inputV, Vector3 position, float speed, Vector2 boundries)
        {
            inputV = Time.deltaTime * speed * inputV;
            var newPosition = new Vector3(inputV.x + position.x, inputV.y + position.y, position.z);

            if (newPosition.x > boundries.x || newPosition.x < -boundries.x)
                newPosition.x = position.x;
            
            if (newPosition.y > boundries.y || newPosition.y < -boundries.y)
                newPosition.y = position.y;

            return newPosition;
        }

        public Quaternion CalculateNewRotation(Vector3 inputV, Quaternion rotation, Vector3 forwardDirection, float rotationSpeed, float maxAngle)
        {
            var cosAngle = Vector3.Dot(forwardDirection, Vector3.right);
            var angle = Mathf.Acos(cosAngle) * Mathf.Rad2Deg;
            
            if (Math.Abs(inputV.y) < Math.Abs(lastYInput))
            {
                if (forwardDirection.y > 0.001f)
                {
                    rotation.eulerAngles += 100 * Time.deltaTime * new Vector3(0,0, -rotationSpeed);
                }

                if (forwardDirection.y < -0.001f)
                {
                    rotation.eulerAngles += 100 * Time.deltaTime * new Vector3(0,0, rotationSpeed);
                }
                
                lastYInput = inputV.y;
                
                return rotation;

            }
            
            lastYInput = inputV.y;
            
            if (angle >= maxAngle)
                return rotation;

            if(inputV.y > 0.001f)
                rotation.eulerAngles += 100 * Time.deltaTime * new Vector3(0, 0, rotationSpeed);
            
            if(inputV.y < -0.001f)
                rotation.eulerAngles += 100 * Time.deltaTime * new Vector3(0, 0, -rotationSpeed);
            
            return rotation;
        }
    }
}