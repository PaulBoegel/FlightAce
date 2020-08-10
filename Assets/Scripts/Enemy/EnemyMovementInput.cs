using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.Enemy
{
    public class EnemyMovementInput: IMovementInput
    {
        private float _horizontalSpeed;
        private float _verticalSpeed;
        private float _amplitude;
        private bool _isBasic;
        private float _basicEnemySpeed;
        
        
        public EnemyMovementInput(bool basicEnemy)
        {
            _horizontalSpeed = Random.Range(-3.5f, -1.2f);
            _verticalSpeed = 3.5f;//Random.Range(1.2f, 3.5f);
            _amplitude = 2.5f;//Random.Range(1.0f, 2.8f);
            _isBasic = basicEnemy;
            _basicEnemySpeed = Random.Range(-3.5f, -1.2f);

        }
        
        private EnemyMovementInput _movementInput;
        
        public Vector3 GetInputVector()
        {
            if (!_isBasic)
            {
                var newPos = new Vector3(x: _horizontalSpeed,y:  Mathf.Sin(Time.realtimeSinceStartup * _verticalSpeed) * _amplitude,z: 0);
                return newPos;
            }
            return new Vector3(_basicEnemySpeed, 0, 0);
        }

    }
}