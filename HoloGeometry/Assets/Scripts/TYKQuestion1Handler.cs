using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TYKQuestion1Handler : MonoBehaviour
{

//public GameObject answer1;

public void answer1Pressed()
{
	GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = Color.green;
}



}
