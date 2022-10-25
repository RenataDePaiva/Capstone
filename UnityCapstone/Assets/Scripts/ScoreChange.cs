using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreChange : MonoBehaviour
{
    private int score;
    private int newScore;
    public static int FinalScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI FinalscoreText;

    void Start() //Displays initial score (0)
    {
        scoreText.text = "" + score;
    }

    public void ScorePoints() //Calculate points to be added and calls function to Update Score when Question is answered correctly, called from QuizManager.correct()
    {
        newScore = 25; //Needs to be updated to make amount of points varied based on the question index
        UpdateScore(newScore);
    }

    void UpdateScore(int scoreToAdd)//Updates and displays updated score, pass value to FinalScore to be displayed at Scoreboard
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
        FinalScore = score;
    }
}