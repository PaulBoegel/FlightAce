using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;

    public void PlayerHealthChanged(int health, int maxHealth)
    {
        float newHealth = 0;

        if (health > 0)
            newHealth = (health / (float) maxHealth) * 100f;
        

        _healthbar.value = Mathf.Round(newHealth);
    }
}
