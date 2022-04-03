using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UI
{
	public class TYKQuestion1Handler : MonoBehaviour
	{
		public String[,] texts;

		void Start()
        {
			texts = new String[10, 5];
            texts[0, 0] = "Pitanje";
            texts[0, 1] = "Odgovor 1";
            texts[0, 2] = "Odgovor 2";
            texts[0, 3] = "Odgovor 3";
			texts[0, 4] = "Odgovor 4";
        }

		public Text question;
		public Text answer1;
		public Text answer2;
		public Text answer3;
		public Text answer4;

		public async Task PutTaskDelay()
		{
			await Task.Delay(5000);
		}

		public void answer1Pressed()
		{
			GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = Color.red;
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			nextQuestion();
		}

		public void answer2Pressed()
		{
			GameObject.Find("Answer 2").GetComponent<UnityEngine.UI.Image>().color = Color.red;
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			nextQuestion();
		}

		public void answer3Pressed()
		{
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			nextQuestion();
		}

		public void answer4Pressed()
		{
			GameObject.Find("Answer 4").GetComponent<UnityEngine.UI.Image>().color = Color.red;
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			nextQuestion();
		}

		public async void nextQuestion()
		{
			//await PutTaskDelay();

			question = GameObject.Find("Question").GetComponentInChildren<UnityEngine.UI.Text>();
			answer1 = GameObject.Find("Answer 1").GetComponentInChildren<UnityEngine.UI.Text>();
			answer2 = GameObject.Find("Answer 2").GetComponentInChildren<UnityEngine.UI.Text>();
			answer3 = GameObject.Find("Answer 3").GetComponentInChildren<UnityEngine.UI.Text>();
			answer4 = GameObject.Find("Answer 4").GetComponentInChildren<UnityEngine.UI.Text>();

			question.text = texts[0, 0];
			answer1.text = texts[0, 1];
			answer2.text = texts[0, 2];
			answer3.text = texts[0, 3];
			answer4.text = texts[0, 4];
		}

	}
}