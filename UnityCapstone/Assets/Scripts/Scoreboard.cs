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
    public TextMeshProUGUI highscore1;
    public TextMeshProUGUI highscore2;
    public TextMeshProUGUI highscore3;
    public bool GameEnds;
    float overwrite;
    float overwrite2;

    void Start()
    {
        overwrite = 0;
        finalScoreText.text = ScoreChange.FinalScore.ToString();
        numCorrectText.text = AnswerScript.numCorrect.ToString()+"/3";
        DisplayPlayedTime(TimerScript.timePlayed);
        SaveHighscore();
    }

    void SaveHighscore()
    {
        if(!PlayerPrefs.HasKey("Highscore1"))//If there are no highscores
        {
            PlayerPrefs.SetFloat("Highscore1", ScoreChange.FinalScore);
            PlayerPrefs.SetFloat("Highscore2", 0);
            PlayerPrefs.SetFloat("Highscore3", 0);
            Debug.Log("Highscore 1 now is : " + PlayerPrefs.GetFloat("Highscore1"));
            DisplayScoreboard();
            return;
        }

        if (PlayerPrefs.HasKey("Highscore1") && !PlayerPrefs.HasKey("Highscore2"))//If there is one highscore
        {
            if (ScoreChange.FinalScore > PlayerPrefs.GetFloat("Highscore1"))
            {
                overwrite = PlayerPrefs.GetFloat("Highscore1");
                PlayerPrefs.SetFloat("Highscore2", overwrite);
                PlayerPrefs.SetFloat("Highscore1", ScoreChange.FinalScore);
                PlayerPrefs.SetFloat("Highscore3", 0);
                Debug.Log("Highscore 1 now is : " + PlayerPrefs.GetFloat("Highscore1"));
                Debug.Log("Highscore 2 now is : " + PlayerPrefs.GetFloat("Highscore2"));
                DisplayScoreboard();
                return;
            }

            else
            {
                PlayerPrefs.SetFloat("Highscore2", ScoreChange.FinalScore);
                Debug.Log("Highscore 2 now is : " + PlayerPrefs.GetFloat("Highscore2"));
                PlayerPrefs.SetFloat("Highscore3", 0);
                DisplayScoreboard();
                return;
            }
        }

        if (PlayerPrefs.HasKey("Highscore1") && PlayerPrefs.HasKey("Highscore2")&& !PlayerPrefs.HasKey("Highscore3"))//If there is highscore one and two
        {
            if (ScoreChange.FinalScore > PlayerPrefs.GetFloat("Highscore1"))
            {
                overwrite = PlayerPrefs.GetFloat("Highscore1");
                overwrite2 = PlayerPrefs.GetFloat("Highscore2");
                PlayerPrefs.SetFloat("Highscore2", overwrite);
                PlayerPrefs.SetFloat("Highscore3", overwrite2);
                PlayerPrefs.SetFloat("Highscore1", ScoreChange.FinalScore);
                Debug.Log("Highscore 1 now is : " + PlayerPrefs.GetFloat("Highscore1"));
                Debug.Log("Highscore 2 now is : " + PlayerPrefs.GetFloat("Highscore2"));
                Debug.Log("Highscore 3 now is : " + PlayerPrefs.GetFloat("Highscore3"));
                DisplayScoreboard();
                return;
            }

            if (ScoreChange.FinalScore < PlayerPrefs.GetFloat("Highscore1") && ScoreChange.FinalScore > PlayerPrefs.GetFloat("Highscore2"))
            {
                overwrite = PlayerPrefs.GetFloat("Highscore2");
                PlayerPrefs.SetFloat("Highscore3", overwrite);
                PlayerPrefs.SetFloat("Highscore2", ScoreChange.FinalScore);
                Debug.Log("Highscore 1 now is : " + PlayerPrefs.GetFloat("Highscore1"));
                Debug.Log("Highscore 2 now is : " + PlayerPrefs.GetFloat("Highscore2"));
                Debug.Log("Highscore 3 now is : " + PlayerPrefs.GetFloat("Highscore3"));
                DisplayScoreboard();
                return;
            }

            else
            {
                PlayerPrefs.SetFloat("Highscore3", ScoreChange.FinalScore);
                Debug.Log("Highscore 3 now is : " + PlayerPrefs.GetFloat("Highscore3"));
                DisplayScoreboard();
                return;
            }
        }

        if (PlayerPrefs.HasKey("Highscore1") && PlayerPrefs.HasKey("Highscore2") && PlayerPrefs.HasKey("Highscore3"))//If all highscores are set
        {
            if (ScoreChange.FinalScore > PlayerPrefs.GetFloat("Highscore1"))
            {
                overwrite = PlayerPrefs.GetFloat("Highscore1");
                overwrite2 = PlayerPrefs.GetFloat("Highscore2");
                PlayerPrefs.SetFloat("Highscore2", overwrite);
                PlayerPrefs.SetFloat("Highscore3", overwrite2);
                PlayerPrefs.SetFloat("Highscore1", ScoreChange.FinalScore);
                Debug.Log("Highscore 1 now is : " + PlayerPrefs.GetFloat("Highscore1"));
                Debug.Log("Highscore 2 now is : " + PlayerPrefs.GetFloat("Highscore2"));
                Debug.Log("Highscore 3 now is : " + PlayerPrefs.GetFloat("Highscore3"));
                DisplayScoreboard();
                return;
            }

            if (ScoreChange.FinalScore < PlayerPrefs.GetFloat("Highscore1") && ScoreChange.FinalScore > PlayerPrefs.GetFloat("Highscore2"))
            {
                overwrite = PlayerPrefs.GetFloat("Highscore2");
                PlayerPrefs.SetFloat("Highscore3", overwrite);
                PlayerPrefs.SetFloat("Highscore2", ScoreChange.FinalScore);
                Debug.Log("Highscore 2 now is : " + PlayerPrefs.GetFloat("Highscore2"));
                Debug.Log("Highscore 3 now is : " + PlayerPrefs.GetFloat("Highscore3"));
                DisplayScoreboard();
                return;
            }

            if (ScoreChange.FinalScore < PlayerPrefs.GetFloat("Highscore1") && ScoreChange.FinalScore < PlayerPrefs.GetFloat("Highscore2") && ScoreChange.FinalScore > PlayerPrefs.GetFloat("Highscore3"))
            {
                PlayerPrefs.SetFloat("Highscore3", ScoreChange.FinalScore);
                Debug.Log("Highscore 3 now is : " + PlayerPrefs.GetFloat("Highscore3"));
                DisplayScoreboard();
                return;
            }

            else
            {
                Debug.Log("No new highscore");
                DisplayScoreboard();
                return;
            }

        }

        else
        {
            Debug.Log("Something Wrong :( ");
        }

    }

    public void DisplayScoreboard()
    {
        highscore1.text = PlayerPrefs.GetFloat("Highscore1", 0).ToString();
        highscore2.text = PlayerPrefs.GetFloat("Highscore2", 0).ToString();
        highscore3.text = PlayerPrefs.GetFloat("Highscore3", 0).ToString();
    }

    public void DisplayPlayedTime(float totalTimeToDisplay)//Formats timePlayed timer to minutes and seconds and assigns value to timePlayedText
    {
        float minutes = Mathf.FloorToInt(totalTimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(totalTimeToDisplay % 60);
        timePlayedText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}