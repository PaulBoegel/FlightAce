using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundhandler : MonoBehaviour
{
    private AudioSource _sounds;

    public AudioClip bulletHit;
    public AudioClip explode;
    void Start()
    {
        _sounds = gameObject.GetComponent<AudioSource>();
       
    }

    public void HitBullet()
    {
        _sounds.PlayOneShot(bulletHit, 1.0f);
    }

    public void Explode()
    {
        _sounds.PlayOneShot(explode, 2.0f);
    }
}
