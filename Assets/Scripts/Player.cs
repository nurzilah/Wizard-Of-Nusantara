using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 3;
    
    public TextMeshProUGUI healthText;

    void Start()
    {
        UpdateHealthDisplay();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            health = 0;
            SceneManager.LoadScene("Death", LoadSceneMode.Additive);
        };
        UpdateHealthDisplay();
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
        UpdateHealthDisplay();
    }

    void UpdateHealthDisplay()
    {
        healthText.text = "Health: " + health + "/" + maxHealth;
    }
}