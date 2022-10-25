using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsScript> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public ScoreChange scoreChange;
    //public TimerScript timerScript;
    public TextMeshProUGUI QuestionTxt;

    private void Start()//Calls function to generate Question as soon as Gamescene loads
    {
        generateQuestion();

    }

    public void correct()//Called from AnswerScript.Answer() if question is answered correctly
    {
        FindObjectOfType<AudioManager>().Play("Correct Answer");
        QnA.RemoveAt(currentQuestion);//Remove current question from array so questions does not repeat
        generateQuestion();
        scoreChange.ScorePoints();//Calls ScorePoints to update score
    }

    public void incorrect()//Called from AnswerScript.Answer() if question is answered incorrectly
    {
        FindObjectOfType<AudioManager>().Play("Wrong Answer");
        QnA.RemoveAt(currentQuestion);//Remove current question from array so questions does not repeat
        generateQuestion();
    }

    void SetAnswers()//Update Options to display correctly
    {
        for (int i = 0; i < options.Length; i++)//For loop to update questions according to Array size
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;//Sets Answers to false by default
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];//Gets TMP for each button so that these can be updated with the options related to the question

            if (QnA[currentQuestion].CorrectAnswer == i)//Allows for programmer to select which option is correct
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void generateQuestion()
    {
        if (QnA.Count > 0)//If there are still questions unanswered, choose a random Question to display
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;//Updates QuestionTxt component to display the question
            SetAnswers();
        }
        else //Loads Scoreboard once player already answered all questions
        {
            //timerScript.timePlayed =  TimerScript.totalTime - timerScript.timeRemaining;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
