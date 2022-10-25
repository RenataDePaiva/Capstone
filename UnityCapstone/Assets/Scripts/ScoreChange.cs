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
    public TimerScript timerScript;
    public static int timeAnswered;

    void Start() //Displays initial score (0), sets FinalScore to zero
    {
        FinalScore = 0;
        scoreText.text = "" + score;
    }

    public void ScorePoints() //Calculate points to be added and calls function to Update Score when Question is answered correctly, called from QuizManager.correct()
    {
        timeAnswered = Mathf.RoundToInt(timerScript.timeRemaining);//Saves the time in each the player answered the question as a integer 

        UpdateScore(timeAnswered * 7);//Points awarded are a result of the time remaining to answer the question, multiplied by 7 (because why not?)

        FindObjectOfType<TimerScript>().RestartTimer();//After points are awarded, restart the timer
    }

    void UpdateScore(int scoreToAdd)//Updates and displays updated score, pass value to FinalScore to be displayed at Scoreboard
    {
        Debug.Log("Correct! Points Received : " + scoreToAdd);
        score += scoreToAdd;
        scoreText.text = "" + score;
        FinalScore = score;
    }
}