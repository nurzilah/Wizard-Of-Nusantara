using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelWin : MonoBehaviour
{
    private int currentLevel;

    private void Start()
    {
        // Ambil nama level terakhir
        string sceneName = PlayerPrefs.GetString("LastPlayedLevel", "Level-1");
        if (sceneName.StartsWith("Level-"))
        {
            string numberStr = sceneName.Replace("Level-", "");
            int.TryParse(numberStr, out currentLevel);
        }
    }

    public void GoToLevelMenu()
    {
        int nextLevel = currentLevel + 1;
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (nextLevel > unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", nextLevel);
            PlayerPrefs.SetInt("JustUnlockedLevel", 1);
            PlayerPrefs.Save();
            Debug.Log($"✅ Level {nextLevel} berhasil dibuka!");
        }
        else
        {
            Debug.Log($"Level {nextLevel} sudah terbuka sebelumnya.");
        }

        SceneManager.LoadScene("Level");
    }
}
