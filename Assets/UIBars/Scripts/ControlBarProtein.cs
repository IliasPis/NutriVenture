//this script is just used for the demo...nothing to see here move along.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ControlBarProtein : MonoBehaviour {

   	public GameObject Banana;
    public GameObject Bread;
    public GameObject Chicken;
    public GameObject Milk;
    public GameObject SweetPotato;
    public GameObject Apple;
    public GameObject OatMilk;
    public GameObject Avoccado;
    public GameObject OliveOil;
    public GameObject Cheddar;
    public GameObject CoconutMilk;
    public GameObject AlmondMilk;
    public GameObject Salmon;

	public GameObject UIBarScriptGet;

	public List<UIBarScript> HPScriptList = new List<UIBarScript>();

	void Start()
	{
		foreach (UIBarScript HPS in HPScriptList)
		{
			HPS.UpdateValue(0,100);
		}
	}

	// Update is called once per frame
	void UpdateBar () 
	{
		 double HP = 0;
        double MaxHP= 0;

		if (!Banana.activeSelf)
        {
            HP+=1.3;
        }

         int roundedHP = Mathf.RoundToInt((float)HP);
         int roundedMaxHP = Mathf.RoundToInt((float)MaxHP);
		 

		//for every UIScript_HP update it.
		foreach (UIBarScript HPS in HPScriptList)
		{
             HPS.UpdateValue(roundedHP, roundedMaxHP);
		}
        
	

	}
}
