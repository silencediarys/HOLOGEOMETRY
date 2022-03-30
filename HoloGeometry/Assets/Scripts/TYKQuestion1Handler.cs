using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UI
{
	public class TYKQuestion1Handler : MonoBehaviour
	{

		public GameObject Question2;

		public async Task PutTaskDelay()
		{
			await Task.Delay(5000);
		}

		public void OpenQuestion2(UIScreen screen)
		{
			if (Question2 != null)
			{
				UISystem.SwitchScreens(screen);
			}
		}

		public void answer1Pressed(UIScreen screen)
		{
			GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = Color.red;
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			nextScreen(screen);
		}

		public void answer2Pressed(UIScreen screen)
		{
			GameObject.Find("Answer 2").GetComponent<UnityEngine.UI.Image>().color = Color.red;
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			nextScreen(screen);
		}

		public void answer3Pressed(UIScreen screen)
		{
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			nextScreen(screen);
		}

		public void answer4Pressed(UIScreen screen)
		{
			GameObject.Find("Answer 4").GetComponent<UnityEngine.UI.Image>().color = Color.red;
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			nextScreen(screen);
		}

		public async void nextScreen(UIScreen screen)
		{
			await PutTaskDelay();

			OpenQuestion2(screen);

		}

	}
}