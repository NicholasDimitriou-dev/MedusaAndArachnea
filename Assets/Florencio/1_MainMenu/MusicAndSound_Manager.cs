using UnityEngine;
using UnityEngine.UI;

public class MusicAndSound_Manager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    public void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadMusic();
        }
        else
        {
            LoadMusic();
        }

        if(!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            LoadSound();
        }
        else
        {
            LoadSound();
        }
    }

    public void Update()
    {
        if(musicSlider == null || soundSlider == null)
        {
            Debug.Log("Return");
            return;
        }
    }

    public void ChangeMusicVolume()
    {
        AudioListener.volume = musicSlider.value;
        SaveMusic();
    }

    public void ChangeSoundVolume()
    {
        AudioListener.volume = soundSlider.value;
        SaveSound();
    }

    public void LoadMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void LoadSound()
    {
        soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    public void SaveMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void SaveSound()
    {
        PlayerPrefs.SetFloat("soundVolume", soundSlider.value);
    }
}