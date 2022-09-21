using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level5 : MonoBehaviour
{
    public TextMeshProUGUI FinalscoreText;
    
    void Start()
    {
        FinalscoreText.text = ScoreChange.FinalScore.ToString();
    }

    void Level6()
    {
        SceneManager.LoadScene("Level6");
    }
}