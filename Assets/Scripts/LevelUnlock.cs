using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUnlock : MonoBehaviour
{
    public Button[] levelButtons;        // Tombol level 1–6
    public GameObject[] lockIcons;       // Ikon gembok untuk level 2–6
    public GameObject lockedPopup;       // Popup saat level terkunci diklik
    public GameObject unlockedPopup;     // Popup saat berhasil unlock level berikutnya

    void Start()
    {
        Debug.Log("Start LevelUnlock");

        if (lockedPopup == null)
            Debug.LogWarning("LockedPopup belum di-assign!");

        if (unlockedPopup == null)
            Debug.LogWarning("UnlockedPopup belum di-assign!");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int capturedLevel = i + 1;

            levelButtons[i].onClick.RemoveAllListeners();
            levelButtons[i].onClick = new Button.ButtonClickedEvent(); // pastikan kosong

            levelButtons[i].interactable = true;

            levelButtons[i].onClick.AddListener(() =>
            {
                int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
                Debug.Log($"Klik Level {capturedLevel}, UnlockedLevel: {unlockedLevel}");

                if (capturedLevel <= unlockedLevel)
                {
                    Debug.Log($"✅ Masuk ke Level-{capturedLevel}");
                    LoadLevel(capturedLevel);
                }
                else
                {
                    Debug.Log($"❌ Level {capturedLevel} masih terkunci!");
                    ShowLockedPopup();
                }
            });

            int currentUnlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);
            bool isLocked = capturedLevel > currentUnlocked;

            if (i < lockIcons.Length)
            {
                lockIcons[i].SetActive(isLocked);

                Image img = lockIcons[i].GetComponent<Image>();
                if (img != null)
                    img.raycastTarget = false;
            }
        }

        if (lockedPopup != null)
            lockedPopup.SetActive(false);

        if (unlockedPopup != null)
            unlockedPopup.SetActive(false);
    }

    void LoadLevel(int level)
    {
        PlayerPrefs.SetInt("LastPlayedLevel", level);
        SceneManager.LoadScene("Level-" + level);
    }

    void ShowLockedPopup()
    {
        if (lockedPopup != null)
        {
            lockedPopup.SetActive(true);
            Invoke("HideLockedPopup", 2f);
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
            Invoke("HideUnlockedPopup", 2f);
        }
    }

    void HideUnlockedPopup()
    {
        if (unlockedPopup != null)
            unlockedPopup.SetActive(false);
    }

    public void UnlockNextLevel(int currentLevel)
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);
        int nextLevel = currentLevel + 1;

        if (nextLevel > unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", nextLevel);
            PlayerPrefs.Save();
            Debug.Log("Unlocked Level " + nextLevel);
            ShowUnlockedPopup();
        }
    }
}
