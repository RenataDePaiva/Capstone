using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreChange : MonoBehaviour
{
    private int score;
    public static int FinalScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI FinalscoreText;

    void Start()
    {
        scoreText.text = "" + score;
    }

    public void HundredPoints() {
        UpdateScore(100);
    }

    public void FifthyPoints()
    {
        UpdateScore(50);
    }

    public void MinusPoints()
    {
        if (score > 0)
        {
            UpdateScore(-25);
        }
    }

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
        FinalScore = score;
    }
}