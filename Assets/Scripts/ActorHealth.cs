using System;
using System.Runtime.InteropServices;
using UnityEditor;
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
    private Soundhandler _soundhandler;

    public void Start()
    {
        _explosionAnim = GetComponent<Animator>();
        _explosionAnim.enabled = false;
        _maxHealth = _health;
        _soundhandler = GetComponent<Soundhandler>();
    }

    public void HandleDamage()
    {
        _health--;
        _soundhandler.HitBullet();
        _takenDamage.Invoke(_health, _maxHealth);
        if (_health <= 0)
            HandleDeath();

    }
    public void HandleDeath()
    {
        _explosionAnim.enabled = true;
        _soundhandler.Explode();
        Destroy(gameObject, 1.00f);
        _death.Invoke();
    }
}
