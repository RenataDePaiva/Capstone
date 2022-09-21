using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;

    //Function called through Resume Button on PauseCanvas
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }
    //Function called through Pause Button
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

    }
}
