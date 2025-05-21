using UnityEngine;
using UnityEngine.SceneManagement; // Untuk reload scene

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathZone")
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Death", LoadSceneMode.Additive);
    }
}