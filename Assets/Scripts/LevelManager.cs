using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Level Menu")]
    public Button[] levelButtons;        // Tombol level 1-6 (isi urut!)
    public GameObject[] lockIcons;       // Gembok level 2-6 (isi urut!)
    public GameObject lockedPopup;       // Popup kalau level diklik tapi belum terbuka
    public GameObject unlockedPopup;     // Popup berhasil unlock (opsional)

    [Header("Gameplay")]
    public int currentLevel = 0;         // Diisi di scene level (bukan scene menu)

    void Start()
    {
        // Kalau di scene menu level, isi tombol
        if (levelButtons.Length > 0)
        {
            SetupLevelMenu();
        }

        // Popup default nonaktif
        if (lockedPopup != null) lockedPopup.SetActive(false);
        if (unlockedPopup != null) unlockedPopup.SetActive(false);
    }

    void SetupLevelMenu()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        Debug.Log($"📌 Unlocked Level = {unlockedLevel}");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelNumber = i + 1;

            // Reset listener
            levelButtons[i].onClick.RemoveAllListeners();

            // Tambahkan event klik
            levelButtons[i].onClick.AddListener(() =>
            {
                if (levelNumber <= unlockedLevel)
                {
                    PlayerPrefs.SetInt("LastPlayedLevel", levelNumber);
                    SceneManager.LoadScene("Level-" + levelNumber);
                }
                else
                {
                    ShowLockedPopup();
                }
            });

            // Atur interaksi tombol & gembok
            bool isUnlocked = levelNumber <= unlockedLevel;
            levelButtons[i].interactable = isUnlocked;

            if (i >= 1 && (i - 1) < lockIcons.Length) // mulai dari Level 2
            {
                lockIcons[i - 1].SetActive(!isUnlocked);
                var img = lockIcons[i - 1].GetComponent<Image>();
                if (img != null) img.raycastTarget = false;
            }
        }
    }

    public void GoToLevelMenu()
    {
        int nextLevel = currentLevel + 1;
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (nextLevel > unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", nextLevel);
            PlayerPrefs.Save();
            Debug.Log($"✅ Unlocked Level {nextLevel}");
            ShowUnlockedPopup();
        }
        else
        {
            Debug.Log($"ℹ️ Level {nextLevel} sudah terbuka sebelumnya");
        }

        SceneManager.LoadScene("Level");
    }


    void ShowLockedPopup()
    {
        if (lockedPopup != null)
        {
            lockedPopup.SetActive(true);
            Invoke(nameof(HideLockedPopup), 2f);
        }
    }

    void HideLockedPopup()
    {
        if (lockedPopup != null)
            lockedPopup.SetActive(false);
    }

    void ShowUnlockedPopup()
    {
        if (unlockedPopup != null)
        {
            unlockedPopup.SetActive(true);
            Invoke(nameof(HideUnlockedPopup), 2f);
        }
    }

    void HideUnlockedPopup()
    {
        if (unlockedPopup != null)
            unlockedPopup.SetActive(false);
    }
}
