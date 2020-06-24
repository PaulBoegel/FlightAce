using FlightAce;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

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
            
            var newPosition = movementCalculator.CalculateNewPosition(Vector3.zero, oldPosition, speed, resolution);
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
            
            var newPosition = movementCalculator.CalculateNewPosition(input, oldPosition, speed, resolution);
            Assert.AreNotEqual(oldPosition, newPosition);
        }

        [Test]
        public void movment_should_stop_if_new_position_reaches_the_resolution_boundaries()
        {
            var movementCalculator = new PlaneMotionCalculator();
            var input = new Vector3(1, 1, 0);
            var oldPosition = new Vector3(10, 10, 0);
            var boundaries = new Vector2(10, 10);
            var speed = 1;
            
            var newPosition = movementCalculator.CalculateNewPosition(input, oldPosition, speed, boundaries);
            Assert.AreEqual(oldPosition, newPosition);
        }
    }
}
