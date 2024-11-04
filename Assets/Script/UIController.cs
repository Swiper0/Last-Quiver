using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider;

    void Start()
    {
        // Set nilai slider sesuai dengan volume yang disimpan
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        // Memastikan volume musik sesuai dengan nilai slider saat start
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
}
