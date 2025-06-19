using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public GameObject DestroyMe;
   public void Destroy()
   {
     DestroyObject(DestroyMe);
   }

}
