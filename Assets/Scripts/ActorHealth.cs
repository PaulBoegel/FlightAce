using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class  DamageEvent : UnityEvent<int, int>  {}
public class ActorHealth : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] private UnityEvent _death;
    private Animator _explosionAnim;

    [SerializeField] private DamageEvent _takenDamage;
    private int _maxHealth;

    public void Start()
    {
        _explosionAnim = GetComponent<Animator>();
        _explosionAnim.enabled = false;
        _maxHealth = _health;
    }

    public void HandleDamage()
    {
        _health--;
        _takenDamage.Invoke(_health, _maxHealth);
        if (_health <= 0)
            HandleDeath();

    }
    public void HandleDeath()
    {
        _explosionAnim.enabled = true;
        Destroy(gameObject, 0.30f);
        Debug.Log("Paul Picasso");
        _death.Invoke();
    }
}
