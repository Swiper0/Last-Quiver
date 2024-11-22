using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds; // Array untuk menyimpan suara musik
    public AudioSource musicSource; // AudioSource untuk memutar musik

    public static AudioManager Instance;

    private const string MusicVolumeKey = "MusicVolume"; // Kunci untuk menyimpan volume

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Muat volume musik dari PlayerPrefs
            LoadMusicVolume();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        PlayMusic("Backsound"); // Ganti "Backsound" dengan nama musik yang sesuai
    }

    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(musicSounds, x => x.name == name); // Temukan suara berdasarkan nama

        if (s == null)
        {
            Debug.Log("Sound Not Found: " + name);
        }
        else
        {
            musicSource.clip = s.clip; // Set AudioClip
            musicSource.Play(); // Putar musik
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        SaveMusicVolume(volume);
    }

    private void LoadMusicVolume()
    {
        // Muat volume dari PlayerPrefs, jika tidak ada, set ke default (1.0)
        float volume = PlayerPrefs.GetFloat(MusicVolumeKey, 1.0f);
        musicSource.volume = volume;
    }

    private void SaveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }
}
