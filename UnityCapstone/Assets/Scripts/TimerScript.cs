using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public static float timePlayed;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public QuizManager quizManager;
    public TextMeshProUGUI timeText;

    private void Start()
    {
        // Starts the timer automatically
        timePlayed = 0;
        timeRemaining = 15;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timePlayed += Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                FindObjectOfType<QuizManager>().RemoveCurrent();//Remove current question from array so questions does not repeat

            }
        }
    }

    public void RestartTimer()//Gets Called by the Answer function inside the Answer script, this way the timer is question specific
    {
        timeRemaining = 15;
    }

    void DisplayTime(float timeToDisplay)//Formats timer to minutes and seconds and assigns value to timeText
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}