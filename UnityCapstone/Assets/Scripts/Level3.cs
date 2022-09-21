using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level3 : MonoBehaviour
{
    public TextMeshProUGUI FinalscoreText;
    public bool GameEnds;

    void Start()
    {
        FinalscoreText.text = ScoreChange.FinalScore.ToString();
    }

    void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
}