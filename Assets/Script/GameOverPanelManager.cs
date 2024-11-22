using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    public Text bestScoreText;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        

        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + ScoreManager.scoreCount;
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0);
    }
}
