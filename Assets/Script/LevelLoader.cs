using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition; // Referensi ke Animator untuk transisi
    public float transitionTime = 1f; // Durasi transisi

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); // Pindah ke level berikutnya
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start"); // Memulai animasi transisi

        yield return new WaitForSeconds(transitionTime); // Tunggu durasi transisi

        SceneManager.LoadScene(levelIndex); // Pindah ke level berikutnya
    }
}
