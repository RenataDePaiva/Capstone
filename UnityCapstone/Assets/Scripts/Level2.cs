using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level2 : MonoBehaviour
{
    public TextMeshProUGUI FinalscoreText;
    private int score;
    public static int FinalScore;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        FinalscoreText.text = ScoreChange.FinalScore.ToString();
    }

    void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        FinalScore = score;
    }
}
