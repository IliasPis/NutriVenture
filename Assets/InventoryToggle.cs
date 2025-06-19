using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject QuestHud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.active == false)
        {
                Time.timeScale = 1f;
                QuestHud.SetActive(true);
        }
        else
        {
                  Time.timeScale = 0f;
                   QuestHud.SetActive(false);
        }
        
    }
}
