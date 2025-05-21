using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Enemy[] enemies;
    public TMP_InputField answerInput;

    public void OnSubmitAnswer()
    {
        string playerAnswer = "";

        if (answerInput != null)
        {
            playerAnswer = answerInput.text;
        }
        else
        {
            Debug.LogError("Answer Input Field is not assigned.");
        }

        if (enemies != null && enemies.Length > 0)
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null && enemy.isInteracting == true)
                {
                    enemy.AnswerQuestion(playerAnswer);
                    CheckAllEnemiesDead();
                    answerInput.text = "";
                }
            }
        }
        else
        {
            Debug.LogError("Enemies array is empty or not assigned.");
        }
    }

    void CheckAllEnemiesDead()
    {
        bool allEnemiesDead = true;

        foreach (var enemy in enemies)
        {
            if (enemy != null && enemy.isActiveAndEnabled)
            {
                allEnemiesDead = false;
                break;
            }
        }

        if (allEnemiesDead)
        {
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
    }
}