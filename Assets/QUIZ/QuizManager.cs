using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public GameObject ExplainPanel; //NEW
    public GameObject NextButton;

    public  GameObject RetryButton;
    public Text QuestionTxt;
    public Text ScoreTxt;

    public Text ExplainTxt; // NEW

    int TotalQuestions = 0;

    int TotalExplains = 0; //NEW
    public int score;

    private void Start()
    {

        TotalQuestions = QnA.Count;
        TotalExplains = QnA.Count;
        GoPanel.SetActive(false);
        NextButton.SetActive(false); 
        ExplainPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        //ResetList();
        QnA.Clear();
        
        TotalQuestions = QnA.Count;
        TotalExplains = QnA.Count;
        GoPanel.SetActive(false);
        NextButton.SetActive(false); 
        ExplainPanel.SetActive(false);
        generateQuestion();
    

    }

    void ResetList()
    {
        QnA = new List<QuestionAndAnswers>(){
            new QuestionAndAnswers()
        };
    }

        public void GetBackDefault(){
         TotalQuestions = QnA.Count;
        TotalExplains = QnA.Count;
        GoPanel.SetActive(false);
        NextButton.SetActive(false); 
        ExplainPanel.SetActive(false);
        generateQuestion();
    }


    public void GameOver()
    {
         Quizpanel.SetActive(false);
         GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + TotalQuestions; 
        //if (score == TotalQuestions){                       
            NextButton.SetActive(true);         
        //}                                               
    }

    public void Explain()  //NEW
    {
        Quizpanel.SetActive(false);
        ExplainPanel.SetActive(true);
        //ExplainTxt.text = QnA[currentQuestion].ExplainWhy;
        StartCoroutine(WaitAfterExplainForNext());
    }

    public void correct()
    {
        //when you answer right 
        score +=1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }

      IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

       IEnumerator WaitAfterExplainForNext() //NEW
    {
        yield return new WaitForSeconds(5);
        GetBackCanvas();
    }

    public void GetBackCanvas() //NEW   
    {
        Quizpanel.SetActive(true);
        ExplainPanel.SetActive(false);
        wrong();
    }

    void SetAnswers()
    {
        for (int i=0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            options [i].GetComponent <Image>().color = options [i].GetComponent <AnswerScript>().startColor;
        
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
  
    }

    public void SetExplaination()  //NEW
    {
         /*for (int i=0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].ExplainWhy[i]; 

        }*/
        //AnswerScript.Answers[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
        
        wrong();
    }

     void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion =  Random.Range(0,QnA.Count); //FIX 

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();

        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
           

    }
}
