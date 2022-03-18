using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class TYKQuestion1Handler : MonoBehaviour
{

	public GameObject Question2;

	public async Task PutTaskDelay()
	{
    await Task.Delay(5000);
	} 

	public void OpenQuestion2()          
	    {
	    if(Question2 != null)
	    {
	      Question2.SetActive(true);
	    }
	}

	public void answer1Pressed()
	{
		GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = Color.red;
		GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
		nextScreen();
	}

	public void answer2Pressed()
	{
		GameObject.Find("Answer 2").GetComponent<UnityEngine.UI.Image>().color = Color.red;
		GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
		nextScreen();
	}

	public void answer3Pressed()
	{
		GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
		nextScreen();
	}

	public void answer4Pressed()
	{
		GameObject.Find("Answer 4").GetComponent<UnityEngine.UI.Image>().color = Color.red;
		GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
		nextScreen();
	}

	public async void nextScreen()
	{
	   await PutTaskDelay();

	   OpenQuestion2();

	}

}
