using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader; // Referensi ke LevelLoader

    public void PlayGame()
    {
        if (levelLoader != null) // Cek jika levelLoader terhubung
        {
            levelLoader.LoadNextLevel(); // Panggil LoadNextLevel untuk memulai transisi dan memuat level baru
        }
        else
        {
            Debug.LogError("LevelLoader reference is not set in MainMenu.");
        }
    }

    public void QuitGame()
    {
        Application.Quit(); // Keluar dari aplikasi
    }
}
