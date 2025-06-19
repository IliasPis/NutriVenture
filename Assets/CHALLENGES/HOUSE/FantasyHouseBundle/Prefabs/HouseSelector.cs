using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HouseSelector : MonoBehaviour
{
     bool WoodOption = false;
     bool BabooOption = false;
     bool ThirdOption=false;
     bool FourthOption=false;

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
        if(WoodOption==true || BabooOption==true || ThirdOption==true || FourthOption==true)
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

       public void WoodClick()
    {
      WoodOption = true;
     score +=100;
     ScoreText.text = score.ToString();
      ScoreText.text = "score: " + score;
      TimeIsRunning=true;
     //SelectorEnable.GetComponent<Text>().text = score.ToString("F0");
    }

       public void BabooClick()
    {
      BabooOption = true;
     score +=60;
     ScoreText.text = score.ToString();
     ScoreText.text = "score: " + score;
     TimeIsRunning=true;
    }

       public void ThridClick()
    {
      ThirdOption = true;
     score+=30;
     ScoreText.text = score.ToString();
     ScoreText.text = "score: " + score;
     TimeIsRunning=true;
    }

       public void FourthClick()
    {
      FourthOption = true;
      ScoreText.text = score.ToString();
      ScoreText.text = "score: " + score;
      TimeIsRunning=true;
    }

}
