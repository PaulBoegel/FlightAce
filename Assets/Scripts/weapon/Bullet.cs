using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        transform.position += transform.up * 10 * Time.deltaTime;
       /***if (gameObject.CompareTag("PlayerBullet"))
        {
            Debug.Log(transform.right);
            rb2d.AddForce(transform.right * 10);
        }
        else
        {
            rb2d.AddForce(-transform.right);
        }***/
        //rb2d.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        
    }

    private void OnBecameInvisible()
    {
        if (gameObject.name == "Bullet(Clone)" || gameObject.name == "EnemyBullet(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
