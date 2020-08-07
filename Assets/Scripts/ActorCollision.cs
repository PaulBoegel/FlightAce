using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent Collied;
    [SerializeField] private UnityEvent Crash;
    [SerializeField] private List<string> ignoreTags;
    [SerializeField] private List<string> crashTags;
    
    
    
    private Sprite matDefault;
    private SpriteRenderer sr;
   

    
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        matDefault = sr.sprite;
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionObject = collision.gameObject;
        var collisionTag = ignoreTags.Find(tag => collisionObject.CompareTag(tag));
        
        if (collisionTag != null)
            return;

        var crashTag = crashTags.Find(tag => collisionObject.CompareTag(tag));

        if (crashTag != null)
        {
            Crash?.Invoke();
            return;
        }
        sr.color = Color.white;
        sr.sprite = null;
        Invoke("ResetMaterial", 0.1f);
        Collied?.Invoke();
    }
    
    private void ResetMaterial()
    {
        sr.sprite = matDefault;
    }
}
