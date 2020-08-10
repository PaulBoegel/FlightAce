using System;
using System.Collections;
using System.Collections.Generic;
using FlightAce.Enemy;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;
    public float reproductionSpeedChange;

    private float _randomY;
    private float _currentYPosition = 0.0f;
    private Vector3 _spawnPosition;
    private float _currentSpawnPos;
    private List<GameObject> _enemys;
    
    private AudioSource _audio;
   
    private float _currentTime;
    private float _currentSpawnTime;

    private GameObject _enem;
    
    void Start()
    {
        _enemys = new List<GameObject>();
        _audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        _currentTime += Time.deltaTime;
        _currentSpawnTime += Time.deltaTime;

        if (_currentSpawnTime >= spawnRate)
        {
            _currentSpawnTime = 0;
            _randomY = _currentYPosition <= 0.0f ? Random.Range(0.0f, 2.5f) : Random.Range(-2.5f, 0.0f) ;
            _currentYPosition = _randomY;
            _spawnPosition = new Vector3(transform.position.x, _randomY, 0);
            _enem = Instantiate(enemy, _spawnPosition, Quaternion.identity);

            _enemys.Add(_enem);
            _audio.Play();
        }

        if (_currentTime >= reproductionSpeedChange && spawnRate >= 2f) 
        {
            spawnRate -= 0.1f;
            _currentTime = 0;
        }
     
    }

    public void PlayAudio()
    {
        _audio.Play();
    }

    public void PauseAudio()
    {
        _audio.Pause();
    }

    public void DeleteEnemys()
    {
        _enemys.ForEach(enemy => Destroy(enemy));
    }
    
}