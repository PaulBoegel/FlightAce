using UnityEngine;

namespace FlightAce
{
    [RequireComponent(typeof(IActorContext))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        private IInput _input;
        private PlaneMotionCalculator _planeMotionCalculator; 
        
        // Start is called before the first frame update
        void Start()
        {
            var context = GetComponent<IActorContext>();
            _planeMotionCalculator = new PlaneMotionCalculator();
            _input = context.Input;
            
        }

        // Update is called once per frame
        void Update()
        {
            var inputV = _input.GetInputVector();
            var boundaries = new Vector2(5, 3);
            transform.position = _planeMotionCalculator.CalculateNewPosition(inputV, transform.position, _movementSpeed, boundaries);
        }
    }
}
