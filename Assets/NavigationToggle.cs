using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationToggle : MonoBehaviour
{
    public GameObject TextgameObject;
    public GameObject NavigationGameObject;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextgameObject.active == false)
        {
            NavigationGameObject.SetActive(true);
            Player.SetActive(true);
        }
        else
        {
             NavigationGameObject.SetActive(false);
             Player.SetActive(false);
        }
        
    }
}
