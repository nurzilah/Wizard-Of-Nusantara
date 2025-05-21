using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public TextMeshProUGUI questionText;
    public GameObject questionPanel;
    public string question = "2 + 2 = ";
    public string correctAnswer = "4";

    private Player playerScript;

    public bool isInteracting = false;

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
        questionPanel.SetActive(false);
    }

    public void AttackPlayer()
    {
        isInteracting = true;
        questionPanel.SetActive(true);
        questionText.text = question;
        Time.timeScale = 0;
    }

    public void AnswerQuestion(string playerAnswer)
    {
        if (playerAnswer.ToLower() == correctAnswer)
        {
            Destroy(gameObject);
        }
        else
        {
            playerScript.TakeDamage(1);
            Destroy(gameObject);
        }

        questionPanel.SetActive(false);
        Time.timeScale = 1;
    }
}