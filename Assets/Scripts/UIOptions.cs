using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIOptions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        highScoreText.text = scoreKeeper.GetHighScore().ToString("000000000");
    }
}
