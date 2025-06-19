using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenJournal : MonoBehaviour
{

    private bool isMenuActive = false;
    public GameObject GameMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

if (Input.GetKeyDown(KeyCode.Tab))
{
        if (isMenuActive)
        {
            GameMenu.SetActive(false);
            isMenuActive = false;
            Cursor.lockState = CursorLockMode.Locked;
             Cursor.visible = false;   
        }
        else
        {
            GameMenu.SetActive(true);
            isMenuActive = true;
            Cursor.lockState = CursorLockMode.None;
             Cursor.visible = true;
        }
 }

        
    }
}
