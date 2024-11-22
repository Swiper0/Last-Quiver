using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text bestScoreText;
    public static int scoreCount;
    private static int bestScore;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void Update()
    {
        scoreText.text = "" + Mathf.Round(scoreCount);
    }

    public void ResetScore()
    {
        scoreCount = 0;
    }

    public void UpdateBestScore()
    {
        if (scoreCount > bestScore)
        {
            bestScore = scoreCount;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    public int GetBestScore()
    {
        return bestScore;
    }
}
