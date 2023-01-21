using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore;
    int highScore;
    

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
     public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public void ModifyScore(int updatedScore)
    {
        currentScore += updatedScore;
        Mathf.Clamp(currentScore, 0, int.MaxValue);

        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
        
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
        //Somehow not working from main menu
    }
   
}
