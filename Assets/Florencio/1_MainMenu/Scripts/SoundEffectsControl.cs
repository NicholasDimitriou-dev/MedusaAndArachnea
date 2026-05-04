// Done
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundEffectsControl : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider soundEffectsSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("soundEffectsVolume"))
        {
            LoadSoundEffectsVolume();
        }
        else
        {
            SetSoundEffectsVolume();
        }
    }

    public void SetSoundEffectsVolume()
    {
        float soundEffectsVolume = soundEffectsSlider.value;

        mixer.SetFloat("soundEffects", Mathf.Log10(soundEffectsVolume) * 20);

        PlayerPrefs.SetFloat("soundEffectsVolume", soundEffectsVolume);
    }

    private void LoadSoundEffectsVolume()
    {
        soundEffectsSlider.value = PlayerPrefs.GetFloat("soundEffectsVolume");

        SetSoundEffectsVolume();
    }
}