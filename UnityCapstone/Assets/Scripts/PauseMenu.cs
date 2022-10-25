using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;

    //Function called through Resume Button on PauseCanvas
    //Function is also called through Back button on PauseCanvas to fix issue with timer staying paused if user chooses to play again after returning to the menu from a paused game
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
