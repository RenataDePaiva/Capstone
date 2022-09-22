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

    public void FifthyPoints()
    {
        UpdateScore(50);
    }

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
        FinalScore = score;
    }
}