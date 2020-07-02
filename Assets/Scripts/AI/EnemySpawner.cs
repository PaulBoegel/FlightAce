using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float randomY;
    private Vector3 spawnPosition;
    public float spawnRate = 2f;
    private float nextSpawn = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomY = Random.Range(-3f, 3f);
            spawnPosition = new Vector3(transform.position.x, randomY, 0);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
}
