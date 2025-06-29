using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject howToPlayPanel;
    public GameObject resetConfirmPopup;

    // ▶️ Play the game
    public void Play()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    // ❌ Exit game
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // 📖 Show "How to Play" panel
    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    // ❌ Close "How to Play" panel
    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }

    // ♻️ Show confirmation popup for Reset Progress
    public void ShowResetPopup()
    {
        resetConfirmPopup.SetActive(true);
    }

    // ✅ YES: Confirm reset progress
    public void ConfirmReset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main Menu");
    }

    // ❌ NO: Cancel reset progress
    public void CancelReset()
    {
        resetConfirmPopup.SetActive(false);
    }
}
