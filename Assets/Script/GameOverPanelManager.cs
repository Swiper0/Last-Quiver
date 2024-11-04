using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelManager : MonoBehaviour
{
    public GameObject gameOverPanel;  // Referensi ke panel Game Over
    public Text scoreText;             // Referensi ke Text untuk Score
    public Text bestScoreText;         // Referensi ke Text untuk Best Score

    private void Start()
    {
        // Pastikan panel Game Over tidak terlihat saat game mulai
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        // Tampilkan panel Game Over
        gameOverPanel.SetActive(true);
        

        // Update score dan best score
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + ScoreManager.scoreCount;
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0); // Mengambil best score dari PlayerPrefs
    }
}
