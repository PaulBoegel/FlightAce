using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _gamePauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleGamePause();
        }
    }

    public void HandleGameOver()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void HandleGameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleGamePause()
    {
        _gamePauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HandleGameResume()
    {
        _gamePauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HandleGameQuit()
    {
        Application.Quit();
    }
}
