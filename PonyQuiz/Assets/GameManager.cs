using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;


    private Question currentQuestion;
    [SerializeField]
    private float tmeBetweenQuestions = 1f;

    [SerializeField]
    private Text puntaje;
    private int cont = 0;

    private int bien = 0;
    private int mal = 0;
    

    [SerializeField]
    private Animator animator;
    void Start()
     
    {
        if (unansweredQuestions == null || unansweredQuestions.Count==0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
       
        

    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        factText.text = currentQuestion.fact;
        if (currentQuestion.isTrue)
        {
         
            trueAnswerText.text = "INCORRECTO";
            falseAnswerText.text = "CORRECTO";
          
           

        }
        else
        {
         
            trueAnswerText.text = "CORRECTO";
            falseAnswerText.text = "INCORRECTO";
           
        }


       

    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(tmeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void UserSelectTrue()
    {
        

       

           animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            bien += 1;
           Debug.Log("Correct");
        }else
        {

            mal += 1;
            Debug.Log("Incorrect");

        }

        if (mal == 5)
        {
            puntaje.text = "Perdiste :(";
            Application.Quit();
        }
        if(bien == 10)
        {
            puntaje.text = "Ganaste c:";
            Application.Quit();
        }




        StartCoroutine(TransitionToNextQuestion());

    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct");
            bien += 1;
            
        }
        else
        {
            mal += 1;
            Debug.Log("Incorrect");
           
        }


        if (mal == 5)
        {
            puntaje.text = "Perdiste :(";
            Application.Quit();

        }
        if (bien == 10)
        {

            puntaje.text = "Ganaste c:";
            Application.Quit();
        }




        StartCoroutine(TransitionToNextQuestion());
    }
}
