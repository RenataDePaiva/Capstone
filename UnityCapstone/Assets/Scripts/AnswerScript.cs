using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public static int numCorrect = 0;
    public QuizManager quizManager;

    public void Start()//Sets numCorrect to zero
    {
        numCorrect = 0;
    }

    public void Answer()
    {
        if (isCorrect)//if Answer is correct call correct() (RestartTimer() is called in ScoreChange so timer only restarts after timeAnswered has already been used on the score calculation
        {
            numCorrect += 1;
            quizManager.correct();
        }
        else//if Answer is incorrect call incorrect() and RestartTimer()
        {
            Debug.Log("Wrong Answer");
            quizManager.incorrect();
        }
    }
}