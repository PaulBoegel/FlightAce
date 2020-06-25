using FlightAce.movement;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PlaneMotionCalculatorTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void position_should_not_be_changed_if_input_is_zero()
        {
            var movementCalculator = new PlaneMotionCalculator();
            var oldPosition = new Vector3(1, 1, 0);
            var resolution = new Vector2(10, 10);
            var speed = 10;
            
            var newPosition = movementCalculator.CalculateNewPosition(Vector3.zero, oldPosition, speed, resolution, 0);
            Assert.AreEqual(oldPosition, newPosition);
        }

        [Test]
        public void position_should_be_changed_if_input_is_unequal_zero()
        {
            var movementCalculator = new PlaneMotionCalculator();
            var oldPosition = new Vector3(1, 1, 0);
            var input = new Vector3(1, 0, 0);
            var resolution = new Vector2(10, 10);
            var speed = 1;
            
            var newPosition = movementCalculator.CalculateNewPosition(input, oldPosition, speed, resolution, 0);
            Assert.AreNotEqual(oldPosition, newPosition);
        }

        [Test]
        public void movment_should_stop_if_new_position_reaches_the_screen_boundaries()
        {
            var movementCalculator = new PlaneMotionCalculator();
            var input = new Vector3(1, 0, 0);
            var oldPosition = new Vector3(10, 10, 0);
            var boundaries = new Vector2(10, 10);
            var speed = 1;
            
            var newPosition = movementCalculator.CalculateNewPosition(input, oldPosition, speed, boundaries, 0);
            Assert.AreEqual(oldPosition, newPosition);
        }

        [Test]
        public void should_not_rotate_without_input()
        {
            var movementCalculator = new PlaneMotionCalculator();
            var inputV = Vector3.zero;
            var rotation = Quaternion.identity;
            var direction = Vector3.right;
            var rotationSpeed = 1;
            var maxAngle = 45;
            
            var newRotation =
                movementCalculator.CalculateNewRotation(inputV, direction, rotationSpeed, maxAngle);
            
            Assert.AreEqual(Quaternion.identity, newRotation);
        }

        [Test]
        public void should_rotate_with_input()
        {
            var movementCalculator = new PlaneMotionCalculator();
            var inputV = new Vector3(0, 1, 0);
            var rotation = Quaternion.identity;
            var direction = Vector3.right;
            var rotationSpeed = 1;
            var maxAngle = 45;
            
            var newRotation =
                movementCalculator.CalculateNewRotation(inputV, direction, rotationSpeed, maxAngle);
            
            Assert.AreNotEqual(Quaternion.identity, newRotation);
        }

        [Test]
        public void should_stop_rotation_at_max_angle()
        {
            var movementCalculator = new PlaneMotionCalculator();
            var inputV = new Vector3(0, 1, 0);
            var rotation = Quaternion.Euler(new Vector3(0, 0, 45f));
            var direction = new Vector3(0.5f, 0.5f, 0);
            var rotationSpeed = 1;
            var maxAngle = 45;
            
            var newRotation =
                movementCalculator.CalculateNewRotation(inputV, direction, rotationSpeed, maxAngle);

            Assert.AreEqual(rotation.eulerAngles, newRotation.eulerAngles);
        }
    }
}
