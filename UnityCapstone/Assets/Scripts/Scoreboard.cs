using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI FinalscoreText;
    //public TextMeshProUGUI TimePlayed;
    public TimerScript timerScript;
    //public GameObject TimerObject;

    void Start()
    {
        FinalscoreText.text = ScoreChange.FinalScore.ToString();
    }
    //void DisplayTimePlayed()
    //{
    //    if (timerScript.timeRemaining > 0)
    //    {
    //        TimerObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = timerScript.timePlayed.ToString();
    //    }
    //}
}