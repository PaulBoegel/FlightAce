﻿using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.movement
{
    [RequireComponent(typeof(IActorContext))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 1;
        
        [Range(0, 5)]
        [SerializeField] private float _rotationSpeed = 1;
        
        [Range(0, 2)]
        [SerializeField] private float _shaking;
        
        [Range(0, 90)]
        [SerializeField] private int _maxRotationAngle = 45;
        
        private IMovementInput _movementInput;
        private PlaneMotionCalculator _planeMotionCalculator;
        private Rigidbody2D rigidBody2D;
        
        // Start is called before the first frame update
        void Start()
        {
            var context = GetComponent<IActorContext>();
            rigidBody2D = context.Rigidbody2D;
            _planeMotionCalculator = new PlaneMotionCalculator();
            _movementInput = context.MovementInput;
            
        }

        // Update is called once per frame
        void Update()
        {
            var inputV = _movementInput.GetInputVector();
            var boundaries = new Vector2(15, 5);
            var trans = transform;
            
            transform.position = _planeMotionCalculator.CalculateNewPosition(inputV, trans.position, _movementSpeed, 
                boundaries, _shaking
                );
            rigidBody2D.MovePosition( _planeMotionCalculator.CalculateNewPosition(inputV, trans.position, _movementSpeed, 
                boundaries, _shaking
            )); 
            transform.rotation = _planeMotionCalculator.CalculateNewRotation(inputV, trans.right, 
                _rotationSpeed,
                _maxRotationAngle
                );
            
            rigidBody2D.MoveRotation( _planeMotionCalculator.CalculateNewRotation(inputV, trans.right, 
                _rotationSpeed,
                _maxRotationAngle
            ));
        }
    }
}
