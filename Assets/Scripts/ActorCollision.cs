using UnityEngine;
using UnityEngine.Events;

public class ActorCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent Collied;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Collied?.Invoke();
    }
}
