using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level4 : MonoBehaviour
{
    public TextMeshProUGUI FinalscoreText;

    void Start()
    {
        FinalscoreText.text = ScoreChange.FinalScore.ToString();
    }

    void Level5()
    {
        SceneManager.LoadScene("Level5");
    }
}
