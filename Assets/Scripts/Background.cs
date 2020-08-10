using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;

    private Vector3 startPOS;

    private AudioClip _backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        startPOS = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * new Vector3(-1, 0, 0));
        if (transform.position.x < -19.29141f)
        {
            transform.position = startPOS;
        }
    }
}
