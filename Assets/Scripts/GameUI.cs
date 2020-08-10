using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverScoreText;
    
    
    private int score = 0;
    

    public void PlayerHealthChanged(int health, int maxHealth)
    {
        float newHealth = 0;

        if (health > 0)
            newHealth = (health / (float) maxHealth) * 100f;
        

        _healthbar.value = Mathf.Round(newHealth);
    }

    public void PlayerPointsIncreased()
    {
        score++;
        _scoreText.text = score.ToString();
        _gameOverScoreText.text = score.ToString();
    }
}
