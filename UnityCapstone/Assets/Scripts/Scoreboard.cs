using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI timePlayedText;
    public TextMeshProUGUI numCorrectText;
    public bool GameEnds;

    void Start()
    {
        finalScoreText.text = ScoreChange.FinalScore.ToString();
        numCorrectText.text = AnswerScript.numCorrect.ToString()+"/3";
        DisplayPlayedTime(TimerScript.timePlayed);
    }

    public void DisplayPlayedTime(float totalTimeToDisplay)//Formats timePlayed timer to minutes and seconds and assigns value to timePlayedText
    {
        float minutes = Mathf.FloorToInt(totalTimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(totalTimeToDisplay % 60);
        timePlayedText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}