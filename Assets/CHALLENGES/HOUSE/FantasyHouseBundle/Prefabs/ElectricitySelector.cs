using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ElectricitySelector : MonoBehaviour
{
     bool WindSelection = false;
     bool SolarSelection = false;
     bool ElectricitySelection=false;

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
        if(WindSelection==true || SolarSelection==true || ElectricitySelection==true )
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

       public void WindClick()
    {
      WindSelection = true;
     score +=100;
     ScoreText.text = score.ToString();
      ScoreText.text = "score: " + score;
      TimeIsRunning=true;
     //SelectorEnable.GetComponent<Text>().text = score.ToString("F0");
    }

       public void SolarClick()
    {
      SolarSelection = true;
     score +=60;
     ScoreText.text = score.ToString();
     ScoreText.text = "score: " + score;
     TimeIsRunning=true;
    }

       public void ElectricityClick()
    {
      ElectricitySelection = true;
     score+=30;
     ScoreText.text = score.ToString();
     ScoreText.text = "score: " + score;
     TimeIsRunning=true;
    }

}
