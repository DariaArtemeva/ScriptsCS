using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour

{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("Slider"))
        {
            PlayerPrefs.SetFloat("Slider", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

 public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Slider");
    }
    private void Save() {
        PlayerPrefs.SetFloat("Slider", volumeSlider.value);
    }

}
