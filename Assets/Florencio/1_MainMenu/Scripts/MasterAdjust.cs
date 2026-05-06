//Done
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterAdjust : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    //[SerializeField] private Slider musicSlider;
    //[SerializeField] private Slider soundEffectsSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("masterVolume"))
        {
            LoadMasterVolume();
        }
        else
        {
            SetMasterVolume();
        }
    }

    public void SetMasterVolume()
    {
        float masterVolume = masterSlider.value;

        mixer.SetFloat("master", Mathf.Log10(masterVolume) * 20);
        //musicSlider.value = masterVolume;
        //soundEffectsSlider.value = masterVolume;

        PlayerPrefs.SetFloat("masterVolume", masterVolume);
    }

    private void LoadMasterVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetMasterVolume();
    }
}