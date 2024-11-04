using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Text untuk menampilkan score
    public Text bestScoreText; // Text untuk menampilkan best score
    public static int scoreCount; // Score saat ini
    private static int bestScore; // Best score

    // Start is called before the first frame update
    void Start()
    {
        // Inisialisasi best score jika belum ada
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + Mathf.Round(scoreCount);
    }

    public void ResetScore()
    {
        scoreCount = 0; // Reset score saat mulai permainan baru
    }

    public void UpdateBestScore()
    {
        if (scoreCount > bestScore)
        {
            bestScore = scoreCount; // Update best score
            PlayerPrefs.SetInt("BestScore", bestScore); // Simpan best score ke PlayerPrefs
            PlayerPrefs.Save(); // Simpan perubahan
        }
    }

    public int GetBestScore()
    {
        return bestScore; // Mengembalikan best score
    }
}
