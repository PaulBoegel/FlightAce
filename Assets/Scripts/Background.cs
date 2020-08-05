using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;

    private Vector3 startPOS;
    // Start is called before the first frame update
    void Start()
    {
        startPOS = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * new Vector3(-1, 0, 0));
        if (transform.position.x < -19.17395f)
        {
            transform.position = startPOS;
        }
    }
}
