using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FlightAce.movement
{

    public class PlaneMotionCalculator
    {
        float lastYInput = 0;
        public Vector3 CalculateNewPosition(Vector3 inputV, Vector3 position, float speed, Vector2 boundaries, float shakingRate)
        {
            inputV = Time.deltaTime * speed * inputV;
            var newPosition = new Vector3(inputV.x + position.x, inputV.y + position.y, position.z);

            if (newPosition.x > boundaries.x || newPosition.x < -boundaries.x)
                newPosition.x = position.x;
            
            if (newPosition.y > boundaries.y || newPosition.y < -boundaries.y)
                newPosition.y = position.y;

            var shaking = new Vector3(0, Random.Range(-shakingRate, shakingRate)) * Time.deltaTime;
            
            return newPosition + shaking;
        }

        public Quaternion CalculateNewRotation(Vector3 inputV, Vector3 forwardDirection, float rotationSpeed, float maxAngle)
        {
            var rotation = Quaternion.identity;
            var cosAngle = Vector3.Dot(forwardDirection, Vector3.right);
            var angle = Mathf.Acos(cosAngle) * Mathf.Rad2Deg;

            var newRotationValue = (forwardDirection.y < 0) ? -angle : angle;

            rotation.eulerAngles = new Vector3(0, 0, newRotationValue);
            
            if (IsRotationInputIdle(inputV))
            {
                return HandleIdleRotationInput(inputV, rotation, forwardDirection, rotationSpeed);
            }
            
            lastYInput = inputV.y;

            if (angle >= maxAngle)
            {
                return HandleMaxAngleReached(forwardDirection, maxAngle);
            }
            
            return HandleRotationInput(inputV, rotation, rotationSpeed);
        }

        private Quaternion HandleMaxAngleReached(Vector3 forwardDirection, float maxAngle)
        {
            var newRotation = Quaternion.identity;
            var maxAngleRotation = (forwardDirection.y < 0) ? -maxAngle : maxAngle;
            newRotation.eulerAngles = new Vector3(0, 0, maxAngleRotation);
            return newRotation;
        }

        private Quaternion HandleRotationInput(Vector3 inputV, Quaternion rotation, float rotationSpeed)
        {
            if (inputV.y > 0.01f)
                rotation.eulerAngles += 100 * Time.deltaTime * new Vector3(0, 0, rotationSpeed);

            if (inputV.y < -0.01f)
                rotation.eulerAngles += 100 * Time.deltaTime * new Vector3(0, 0, -rotationSpeed);

            return rotation;
        }

        private Quaternion HandleIdleRotationInput(Vector3 inputV, Quaternion rotation, Vector3 forwardDirection, float rotationSpeed)
        {
            if (forwardDirection.y > 0.01f)
            {
                rotation.eulerAngles += 100 * Time.deltaTime * new Vector3(0, 0, -rotationSpeed);
            }

            if (forwardDirection.y < -0.01f)
            {
                rotation.eulerAngles += 100 * Time.deltaTime * new Vector3(0, 0, rotationSpeed);
            }

            lastYInput = inputV.y;

            return rotation;
        }
        
        private bool IsRotationInputIdle(Vector3 inputV)
        {
            return Math.Abs(inputV.y) < Math.Abs(lastYInput) || Math.Abs(inputV.y) < 0.01f;
        }
    }
}