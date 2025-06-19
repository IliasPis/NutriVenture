using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMiniGame : MonoBehaviour
{
     public GameObject MyObject;
    public Button ChangeBarClickButton;
    public GameObject ButtonNext;

   void Update()
    {
        if (!MyObject.activeSelf && !ButtonNext.activeSelf)
        {
            ChangeBarClickButton.onClick.Invoke();
            ButtonNext.SetActive(true);
            Destroy(this);
        }
    }
}
