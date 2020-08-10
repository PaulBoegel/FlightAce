using System;
using System.Collections;
using FlightAce.Enemy;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _gamePauseMenu;
    [SerializeField] private GameUI _ui;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private AudioSource _playerAudio;
    [SerializeField] private  AudioSource backGroundMusic;
    [SerializeField] private  AudioClip pauseMenu;
    [SerializeField] private  AudioClip backGroundClip;
    [SerializeField] private UnityEvent EnemyDied;

  
    private bool _isPaused;
    
    private void Start()
    {
        backGroundClip = backGroundMusic.clip;
        EnemyContext.OnEnemyDied += HandleEnemyDeath;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleGamePause();
        }
    }

    public void HandleGameOver()
    {
        _playerAudio.Stop();
        _enemySpawner.PauseAudio();
        _enemySpawner.enabled = false;
        _ui.gameObject.SetActive(false);
        _ui.gameObject.SetActive(false); 
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0.1f;
    }
    
    public void HandleGameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleGamePause()
    {
        if (_isPaused)
        {
            HandleGameResume();
            _isPaused = false;
            return;
        }
        
        _isPaused = true;
        _playerAudio.Pause();
        _enemySpawner.PauseAudio();
        backGroundMusic.clip = pauseMenu;
        backGroundMusic.Play();
        _gamePauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HandleGameResume()
    {
        _isPaused = false;
        backGroundMusic.clip = backGroundClip;
        backGroundMusic.Play();
        _playerAudio.Play();
        _enemySpawner.PlayAudio();
        _gamePauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HandleGameQuit()
    {
        Application.Quit();
    }
    
    public void HandleEnemyDeath()
    {
        EnemyDied?.Invoke();
    }
    
    public void OnDestroy()
    {
        EnemyContext.OnEnemyDied -= HandleEnemyDeath;
    }
}
