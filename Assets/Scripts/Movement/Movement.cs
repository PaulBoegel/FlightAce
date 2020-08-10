using FlightAce.interfaces;
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

        [SerializeField] private Vector2 _boundaries;
        
        
        private IMovementInput _movementInput;
        private IActualRole _actualRole;
        private PlaneMotionCalculator _planeMotionCalculator;

        // Start is called before the first frame update
        void Start()
        {
            var context = GetComponent<IActorContext>();
            _planeMotionCalculator = new PlaneMotionCalculator();
            _movementInput = context.MovementInput;
            _actualRole = context.ActualRole;

        }

        // Update is called once per frame
        void Update()
        {
            var inputV = _movementInput.GetInputVector();
            var trans = transform;
            
            transform.position = _planeMotionCalculator.CalculateNewPosition(inputV, trans.position, _movementSpeed, 
                _boundaries, _shaking
                );
      
            transform.rotation = _planeMotionCalculator.CalculateNewRotation(inputV, trans.right, 
                _rotationSpeed,
                _maxRotationAngle
                );
            
        }
    }
}
