using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoceSelector : MonoBehaviour
{
     bool WalkSelection = false;
     bool BikeSelection = false;
     bool CarSelection=false;

     bool TimeIsRunning = false;

     public float timeRemaining = 10;

    public static float score=0;

    public Text ScoreText;

    public GameObject SelectorEnable;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(WalkSelection==true || BikeSelection==true || CarSelection==true )
        {
            SelectorEnable.SetActive(true);
        }

        if (TimeIsRunning == true && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0)
        {
            SelectorEnable.SetActive(false);

        }

    }

       public void WalkClick()
    {
      WalkSelection = true;
     score +=100;
     ScoreText.text = score.ToString();
      ScoreText.text = "score: " + score;
      TimeIsRunning=true;
     //SelectorEnable.GetComponent<Text>().text = score.ToString("F0");
    }

       public void BikeClick()
    {
      BikeSelection = true;
     score +=60;
     ScoreText.text = score.ToString();
     ScoreText.text = "score: " + score;
     TimeIsRunning=true;
    }

       public void CarClick()
    {
      CarSelection = true;
     score+=30;
     ScoreText.text = score.ToString();
     ScoreText.text = "score: " + score;
     TimeIsRunning=true;
    }

}
