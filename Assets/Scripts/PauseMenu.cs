using System;
using System.Collections;
using System.Collections.Generic;
using NSubstitute.Exceptions;
using UnityEditor;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource backGroundMusic;
    public AudioClip pauseMenu;
    private AudioClip baackGroundClip;

    private void Start()
    {
        baackGroundClip = backGroundMusic.clip;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        backGroundMusic.clip = baackGroundClip;
        backGroundMusic.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        backGroundMusic.clip = pauseMenu;
        backGroundMusic.Play();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
