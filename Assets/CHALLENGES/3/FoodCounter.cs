using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

namespace FinalChallenge
{
public class FoodCounter : MonoBehaviour
{

    public bool IsPotato;
    public bool IsBroccoli;
    public bool IsTomato;
    public bool IsSweetPotato;
    public bool IsReddish;
    public bool IsPepper;
    public bool IsMarul;
    public bool IsCucumber;

    public Image PotatoImg;
    public Image BroccoliImg;
    public Image TomatoImg;
    public Image SweetPotatoImg;
    public Image ReddishImg;
    public Image PepperImg;
    public Image MarulImg;
    public Image CucumberImg;


    public GameObject Potato;
    public GameObject Brocoli;
    public GameObject Tomato;
    public GameObject SweetPotato;
    public GameObject Reddish;
    public GameObject Pepper;
    public GameObject Marul;
    public GameObject Cocumber;

    public DragScript DragScript;

    public int PotatoPH;
    public int BroccoliPH;
    public int TomatoPH;
    public int SweetPotatoPH;
    public int ReddishPH;
    public int PepperPH;
    public int MarulPH;
    public int CucumberPH;


    public int ScoreFromFood=0;

    // Start is called before the first frame update
    void Start()
    {
        IsPotato=false;
        IsBroccoli=false;
        IsTomato=false;
        IsSweetPotato=false;
        IsReddish=false;
        IsPepper=false;
        IsMarul=false;
        IsCucumber=false;

        PotatoImg.gameObject.SetActive(false);
        BroccoliImg.gameObject.SetActive(false);
        TomatoImg.gameObject.SetActive(false);
        SweetPotatoImg.gameObject.SetActive(false);
        ReddishImg.gameObject.SetActive(false);
        PepperImg.gameObject.SetActive(false);
        MarulImg.gameObject.SetActive(false);
        CucumberImg.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Potato.activeSelf)
        {
            IsPotato=true;
        }
        if (!Brocoli.activeSelf)
        {
            IsBroccoli=true;
        }
        if (!Tomato.activeSelf)
        {
            IsTomato=true;
        }
        if (!SweetPotato.activeSelf)
        {
            IsSweetPotato=true;
            SweetPotatoImg.enabled=true;
        }
        if (!Reddish.activeSelf)
        {
            IsReddish=true;
        }
        if (!Pepper.activeSelf)
        {
            IsPepper=true;
        }
        if (!Cocumber.activeSelf)
        {
            IsCucumber=true;
        }
        if (!Marul.activeSelf)
        {
            IsMarul=true;
        }


        if(IsPotato==true)
        {
            PotatoImg.gameObject.SetActive(true);
        }
        if(IsBroccoli==true)
        {
            BroccoliImg.gameObject.SetActive(true);
        }
        if(IsTomato==true)
        {
            TomatoImg.gameObject.SetActive(true);
        }
        if(IsSweetPotato==true)
        {
            SweetPotatoImg.gameObject.SetActive(true);
        }
        if(IsReddish==true)
        {
            ReddishImg.gameObject.SetActive(true);
        }
        if(IsPepper==true)
        {
            PepperImg.gameObject.SetActive(true);
        }
        if(IsMarul==true)
        {
            MarulImg.gameObject.SetActive(true);
        }
        if(IsCucumber==true)
        {
            CucumberImg.gameObject.SetActive(true);
        }



        
    }
}

}