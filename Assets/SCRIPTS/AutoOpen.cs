using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOpen : MonoBehaviour
{
    public GameObject ObjectToCheck;
    public GameObject ObjectToActive;

    public GameObject PreviousBar;
    public GameObject NewBar;

    // Update is called once per frame
    public void Start()
    {
        if(!ObjectToCheck.activeSelf)
        {
            ObjectToActive.SetActive(true);
            PreviousBar.SetActive(false);
            NewBar.SetActive(true);
        }
        
    }
}
