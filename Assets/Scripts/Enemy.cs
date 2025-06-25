using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public TextMeshProUGUI questionText;
    public GameObject questionPanel;
    public string question = "2 + 2 = ";
    public string correctAnswer = "4";

    public GameObject wrongAnswerPopup; // ➕ Tambahan: popup UI
    private Player playerScript;

    public bool isInteracting = false;

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
        questionPanel.SetActive(false);
        
        if (wrongAnswerPopup != null)
        {
            wrongAnswerPopup.SetActive(false); // pastikan popup awalnya mati
        }
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
        string cleanAnswer = playerAnswer.Trim().ToLower();
        string cleanCorrect = correctAnswer.Trim().ToLower();

        if (cleanAnswer == cleanCorrect)
        {
            Destroy(gameObject); // Jawaban benar, musuh hilang
            questionPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            playerScript.TakeDamage(1); // Jawaban salah, kena damage
            questionPanel.SetActive(false);
            ShowWrongAnswerPopup();
        }
    }

    void ShowWrongAnswerPopup()
    {
        if (wrongAnswerPopup != null)
        {
            wrongAnswerPopup.SetActive(true);
            Invoke("HideWrongAnswerPopup", 2f); // popup hilang setelah 2 detik
        }

        Time.timeScale = 1; // lanjutkan game
        isInteracting = false;
    }

    void HideWrongAnswerPopup()
    {
        if (wrongAnswerPopup != null)
        {
            wrongAnswerPopup.SetActive(false);
        }
    }
}
