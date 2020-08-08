using System;
using System.Runtime.InteropServices;
using FlightAce.interfaces;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class  DamageEvent : UnityEvent<int, int>  {}
public class ActorHealth : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] private UnityEvent _death;
    private Animator _explosionAnim;
    private bool isDead = false;

    [SerializeField] private DamageEvent _takenDamage;
    private int _maxHealth;
    private Soundhandler _soundhandler;

   
    

    public void Start()
    {
        _explosionAnim = GetComponent<Animator>();
        _explosionAnim.runtimeAnimatorController.animationClips[0].wrapMode = WrapMode.Once;
        _explosionAnim.enabled = false;
        _maxHealth = _health;
        _soundhandler = GetComponent<Soundhandler>();
        
    }

    public void HandleDamage()
    {
        _health--;
        _soundhandler.HitBullet();
        _takenDamage.Invoke(_health, _maxHealth);
        if (_health <= 0 && isDead == false)
        {
            HandleDeath();
        }
            



    }
    public void HandleDeath()
    {
        isDead = true;
        _explosionAnim.enabled = true;
        _soundhandler.Explode();
        //var muzzle = gameObject.transform.GetChild(0).gameObject;
        //Destroy(muzzle);
        Destroy(gameObject,1.00f);
        _death.Invoke();
    }

}
