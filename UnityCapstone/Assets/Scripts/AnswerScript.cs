using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if (isCorrect)//if Answer is correct call correct()
        {
            quizManager.correct();
        }
        else//if Answer is incorrect call incorrect()
        {
            Debug.Log("Wrong Answer");
            quizManager.incorrect();
        }
    }
}