using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public QuestionsScript[] questionsList;
    private static List<QuestionsScript> unansweredQuestions;
    private QuestionsScript currentQuestion;

    void Start()
    {
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questionsList.ToList<QuestionsScript>();
        }

        GetRandomQuestion();

        Debug.Log(currentQuestion.question + " is " + currentQuestion.isCorrect);
    }
    void GetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }
}
