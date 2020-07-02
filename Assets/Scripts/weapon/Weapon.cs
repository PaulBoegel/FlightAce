using System;
using System.Collections;
using FlightAce.interfaces;
using UnityEngine;
using UnityEngine.Serialization;

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
        private GameObject _muzzle;
        private bool _bulletIsLoaded;

        // Start is called before the first frame update
        void Start()
        {
            var context = GetComponent<IActorContext>();
            _weaponInput = context.WeaponInput;
            _muzzle = _muzzleFlash.gameObject;
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
                Debug.DrawRay(muzzleTrans.position, muzzleTrans.right * 100, Color.red, 1f);
            
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
    }
}
