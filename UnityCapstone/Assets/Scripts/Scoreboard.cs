using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI FinalscoreText;
    public bool GameEnds;

    void Start()
    {
        FinalscoreText.text = ScoreChange.FinalScore.ToString();
    }

}