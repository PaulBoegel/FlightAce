using System;
using UnityEngine;
using UnityEngine.Events;

public class ActorHealth : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] private UnityEvent _death;
    private Animator _explosionAnim;
  

    private void Start()
    {
        _explosionAnim = GetComponent<Animator>();
        _explosionAnim.enabled = false;
    }

    public void HandleDamage()
    {
        _health--;
        if (_health <= 0)
        {
            Death();
        }
         

    }
    private void Death()
    {
        _explosionAnim.enabled = true;
        Destroy(gameObject, 0.30f);
        Debug.Log("Paul Picasso");
        _death.Invoke();
    }
}
