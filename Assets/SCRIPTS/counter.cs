using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{
public Text t1;
public float timer;
// Use this for initialization
void Start () {
	t1 = GetComponent<Text> ();
}

// Update is called once per frame
void Update () {
	timer -= Time.deltaTime;

	t1.text = " counter : " + timer;

}
}