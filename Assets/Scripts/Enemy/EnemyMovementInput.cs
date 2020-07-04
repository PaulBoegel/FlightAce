using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.Enemy
{
    public class EnemyMovementInput: IMovementInput
    {
        private float horizontalSpeed;
        private float verticalSpeed;
        private float amplitude;
        private bool isBasic;
        public EnemyMovementInput(bool basicEnemy)
        {
            horizontalSpeed = Random.Range(-1.0f, -0.3f);
            verticalSpeed = Random.Range(0.3f, 1.0f);
            amplitude = Random.Range(0.1f, 1.0f);
            isBasic = basicEnemy;
        }
        
        private EnemyMovementInput _movementInput;
        
        public Vector3 GetInputVector()
        {
            if (!isBasic)
            {
                var newPos = new Vector3(x: horizontalSpeed,y:  Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude,z: 0);
                return newPos;
            }
            return new Vector3(Random.Range(-1.0f, -0.5f), 0, 0);
        }
    }
}