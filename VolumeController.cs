using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


[RequireComponent(typeof(AudioSource))]
public class VolumeController : MonoBehaviour
{
    public static VolumeController Instance { get; private set; }
    public LinearMapping linearMapping;
    private const string VolumePrefKey = "SavedVolume";
    private List<AudioSource> audioSources = new List<AudioSource>();

    private void Awake()
    {
     
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        UpdateAudioSources();

     
        if (PlayerPrefs.HasKey(VolumePrefKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey);
            foreach (var source in audioSources)
            {
                source.volume = savedVolume;
            }
            if (linearMapping != null)
            {
                linearMapping.value = savedVolume;
            }
        }
    }

    private void Update()
    {
        if (linearMapping != null)
        {
            float volume = linearMapping.value;
            foreach (var source in audioSources)
            {
                source.volume = volume;
            }
     
            PlayerPrefs.SetFloat(VolumePrefKey, volume);
        }
    }

 
    public void UpdateAudioSources()
    {
        audioSources.Clear();
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        audioSources.AddRange(sources);
    }

    private void OnLevelWasLoaded(int level)
    {
       
        UpdateAudioSources();

    
        if (PlayerPrefs.HasKey(VolumePrefKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey);
            foreach (var source in audioSources)
            {
                source.volume = savedVolume;
            }
        }
    }
}