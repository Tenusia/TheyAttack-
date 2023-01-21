using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    [SerializeField] float sceneBossLoadDelay = 5f;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainScreen");
    }
    
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("MainLevel");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void LoadBossBattle()
    {
        StartCoroutine(WaitAndLoad("BossLevel", sceneBossLoadDelay));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(WaitAndLoad("MainLevelLoopHard", sceneBossLoadDelay));
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingScreen");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
