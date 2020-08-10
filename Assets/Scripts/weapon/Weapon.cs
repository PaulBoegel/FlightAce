using System;
using System.Collections;
using FlightAce.interfaces;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace FlightAce.weapon
{
    [RequireComponent(typeof(IActorContext))]
    public class Weapon : MonoBehaviour
    {

        [Range(0, 100)] [SerializeField] private float _fireDelay = 1;
        [SerializeField] private SpriteRenderer _muzzleFlash;
        [SerializeField] private SpriteRenderer _bulletShoot;
        [SerializeField] private bool _debugMode = false;

        private IWeaponInput _weaponInput;
        private IActualRole _actualRole;
        private GameObject _muzzle;
        private GameObject _bullet;
        private bool _bulletIsLoaded;
        private bool _isShooting;

        // Start is called before the first frame update
        void Start()
        {
            var context = GetComponent<IActorContext>();
            _weaponInput = context.WeaponInput;
            _actualRole = context.ActualRole;
            _muzzle = _muzzleFlash.gameObject;
            _bullet = _bulletShoot.gameObject;
            //InvokeRepeating("EnemyShooting", Random.Range(0.5f, 1.5f), Random.Range(0.3f, 0.3f));
            StartCoroutine("EnemShooting");
            StartCoroutine("LoadBullet");
            StartCoroutine("MuzzleDelay");
        }

        // Update is called once per frame
        void Update()
        {
            if (_weaponInput.isFireing() && _muzzle)
            {
                _muzzle.SetActive(true);
                if (_bulletIsLoaded)
                {
                    var bullet = Instantiate(_bullet,
                        new Vector3(_muzzle.transform.position.x, _muzzle.transform.position.y, 0),
                        Quaternion.identity);
                    bullet.transform.eulerAngles = new Vector3(_muzzle.transform.eulerAngles.x,
                        _muzzle.transform.eulerAngles.y,
                        _actualRole.isEnemy()
                            ? _muzzle.transform.eulerAngles.z + 90
                            : _muzzle.transform.eulerAngles.z - 90);
                    _bulletIsLoaded = false;
                }

                if (_isShooting)
                {
                    _muzzleFlash.enabled = true;
                    _isShooting = false;
                    return;
                }

                _muzzleFlash.enabled = false;
                return;
            }

            if (_muzzle)
                _muzzleFlash.gameObject.SetActive(false);

        }

        private void FixedUpdate()
        {
            if (_weaponInput.isFireing() && _bulletIsLoaded)
                FireRaycast();
        }

        private void FireRaycast()
        {
            if (_muzzle)
            {
                var muzzleTrans = _muzzle.transform;
                var hit = Physics2D.Raycast(muzzleTrans.position, muzzleTrans.right);

                if (_debugMode)
                    Debug.DrawRay(muzzleTrans.position,
                        _actualRole.isEnemy() ? -muzzleTrans.right * 100 : muzzleTrans.right * 100, Color.red, 1f);

                if (hit.collider != null)
                {
                    //if(_debugMode)
                    // Debug.Log(hit.transform.gameObject.name);
                }

            }

        }

        IEnumerator LoadBullet()
        {
            while (true)
            {
                yield return new WaitForSeconds(_fireDelay * 0.3f);
                _bulletIsLoaded = true;
            }
        }

        IEnumerator MuzzleDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(_fireDelay * 0.01f);
                _isShooting = true;
            }
        }

        private void EnemyShooting()
        {
            if (_actualRole.isEnemy())
            {
                _weaponInput.setEnemyShooting();
            }
        }

        IEnumerator EnemShooting()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
                if (!_weaponInput.isFireing())
                {
                    yield return new WaitForSeconds(Random.Range(0.5f, 0.8f));
                }
                if (_actualRole.isEnemy())
                {
                    _weaponInput.setEnemyShooting();
                }
            }
        }
    }

}