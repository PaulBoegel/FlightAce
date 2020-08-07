using UnityEngine;
using UnityEngine.Events;

public class ActorHealth : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] private UnityEvent _death;
    
    public void HandleDamage()
    {
        _health--;
        if (_health <= 0)
            Death();

    }
    private void Death()
    {
        gameObject.SetActive(false);
        _death.Invoke();
    }
}
