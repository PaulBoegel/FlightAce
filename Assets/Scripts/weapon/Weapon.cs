using System;
using System.Collections;
using FlightAce.interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace FlightAce.weapon
{
    [RequireComponent(typeof(IActorContext))]
    public class Weapon : MonoBehaviour
    {
        
        [Range(0, 100)]
        [SerializeField] private float _fireDelay = 1;
        [SerializeField] private SpriteRenderer _muzzleFlash;
        [SerializeField] private bool _debugMode = false;
        
        
        private IWeaponInput _weaponInput;
        private IActualRole _actualRole;
        private GameObject _muzzle;
        private bool _bulletIsLoaded;

        // Start is called before the first frame update
        void Start()
        {
            var context = GetComponent<IActorContext>();
            _weaponInput = context.WeaponInput;
            _actualRole = context.ActualRole;
            _muzzle = _muzzleFlash.gameObject;
            InvokeRepeating("EnemyShooting", Random.Range(0.1f, 1.0f), Random.Range(0.5f, 1.5f));
            StartCoroutine("LoadBullet");
        }

        // Update is called once per frame
        void Update()
        {
            if (_weaponInput.isFireing())
            {
                _muzzle.SetActive(true);
                if (_bulletIsLoaded)
                {
                    _muzzleFlash.enabled = true;
                    _bulletIsLoaded = false;
                    return;
                }
                
                _muzzleFlash.enabled = false;
                return;
            }
            
            _muzzleFlash.gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (_weaponInput.isFireing() && _bulletIsLoaded)
                FireRaycast();
        }

        private void FireRaycast()
        {
            var muzzleTrans = _muzzle.transform;
            var hit = Physics2D.Raycast(muzzleTrans.position, muzzleTrans.right);
            
            if (_debugMode)
                Debug.DrawRay(muzzleTrans.position,  _actualRole.isEnemy() ? -muzzleTrans.right * 100 : muzzleTrans.right * 100, Color.red, 1f);
            
            if (hit.collider != null)
            {
                if(_debugMode)
                    Debug.Log(hit.transform.gameObject.name);
            }
        }
        
        IEnumerator LoadBullet()
        {
            while (true)
            {
                yield return new WaitForSeconds(_fireDelay * 0.01f);
                _bulletIsLoaded = true;
            }
        }

        private void EnemyShooting()
        {
            if (_actualRole.isEnemy())
            {
                _weaponInput.setEnemyShooting();
            }
            
        }
    }
}
