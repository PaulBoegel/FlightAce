using System.Collections;
using FlightAce.interfaces;
using UnityEngine;

namespace FlightAce.weapon
{
    [RequireComponent(typeof(IActorContext))]
    public class Weapon : MonoBehaviour
    {

        [SerializeField] private SpriteRenderer _muzzleFlash;

        private IWeaponInput _weaponInput;

        // Start is called before the first frame update
        void Start()
        {
            var context = GetComponent<IActorContext>();
            _weaponInput = context.WeaponInput;
            StartCoroutine("MuzzleFlashAnimation");
        }

        // Update is called once per frame
        void Update()
        {
            if (_weaponInput.isFireing())
            {
                _muzzleFlash.gameObject.SetActive(true);
                return;
            }
            
            _muzzleFlash.gameObject.SetActive(false);
        }

        IEnumerator MuzzleFlashAnimation()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                if (_weaponInput.isFireing())
                    _muzzleFlash.enabled = !_muzzleFlash.enabled;  
                
            }
        }
    }
}
