using UnityEngine;
using UnityEngine.UI;

public class SoundToggleSingle : MonoBehaviour
{
    public AudioSource audioSource;        // Target AudioSource
    public Sprite iconSoundOn;             // Gambar speaker ON
    public Sprite iconSoundOff;            // Gambar speaker OFF
    public Image buttonImage;              // Komponen Image di tombol

    void Start()
    {
        UpdateIcon();  // set icon awal
    }

    public void ToggleSound()
    {
        audioSource.mute = !audioSource.mute;
        UpdateIcon();
    }

    void UpdateIcon()
    {
        buttonImage.sprite = audioSource.mute ? iconSoundOff : iconSoundOn;
    }
}
