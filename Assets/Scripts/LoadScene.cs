using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void paused()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Time.timeScale = 1; // pastikan waktu jalan normal lagi
        SceneManager.LoadScene("Main Menu");
    }

    public void LevelGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1; // reset waktu sebelum restart
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
