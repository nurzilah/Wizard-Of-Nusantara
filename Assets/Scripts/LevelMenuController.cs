using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject lockedPopup;
    public GameObject unlockedPopup;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        Debug.Log("Unlocked Level = " + unlockedLevel);

        // Atur status tombol dan gembok
        for (int i = 0; i < levelButtons.Length; i++)
        {
            bool isUnlocked = (i < unlockedLevel);
            levelButtons[i].interactable = isUnlocked;

            Transform lockIcon = levelButtons[i].transform.Find("LockIcon");
            if (lockIcon != null)
            {
                lockIcon.gameObject.SetActive(!isUnlocked);
            }
        }

        // Tampilkan popup jika barusan unlock level
        if (PlayerPrefs.GetInt("JustUnlockedLevel", 0) == 1)
        {
            if (unlockedPopup != null)
            {
                unlockedPopup.SetActive(true);
            }
            PlayerPrefs.SetInt("JustUnlockedLevel", 0); // reset agar tidak muncul terus
            PlayerPrefs.Save();
        }
    }

    public void OpenLevel(int level)
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (level <= unlockedLevel)
        {
            SceneManager.LoadScene("Level-" + level);
        }
        else
        {
            Debug.Log($"🚫 Level {level} masih terkunci!");

            if (lockedPopup != null)
            {
                lockedPopup.SetActive(true);
            }
        }
    }

    public void ClosePopup(GameObject popup)
    {
        popup.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
