using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace UI
{
	public class TYKQuestion1Handler : MonoBehaviour
	{
		public String[,] texts;
		public Text question;
		public Text answer1;
		public Text answer2;
		public Text answer3;
		public Text answer4;
		private int questionId;
		private int correctPos;

		void Start()
        {
			// Initializing all questions
			question = GameObject.Find("Question").GetComponentInChildren<UnityEngine.UI.Text>();
			answer1 = GameObject.Find("Answer 1").GetComponentInChildren<UnityEngine.UI.Text>();
			answer2 = GameObject.Find("Answer 2").GetComponentInChildren<UnityEngine.UI.Text>();
			answer3 = GameObject.Find("Answer 3").GetComponentInChildren<UnityEngine.UI.Text>();
			answer4 = GameObject.Find("Answer 4").GetComponentInChildren<UnityEngine.UI.Text>();

			texts = new String[10, 5];
            texts[0, 0] = "Pitanje";
            texts[0, 1] = "Odgovor 1";
            texts[0, 2] = "Odgovor 2";
            texts[0, 3] = "Odgovor 3";
			texts[0, 4] = "Odgovor 4";

			texts[1, 0] = "Question";
            texts[1, 1] = "Answer 1";
            texts[1, 2] = "Answer 2";
            texts[1, 3] = "Answer 3";
			texts[1, 4] = "Answer 4";

			texts[2, 0] = "Question 3";
            texts[2, 1] = "Answer 1";
            texts[2, 2] = "Answer 2";
            texts[2, 3] = "Answer 3";
			texts[2, 4] = "Answer 4";

			questionId = 0;
			
			loadQuestion(questionId);

        }

		public async Task PutTaskDelay()
		{
			GameObject.Find("Answer 1").GetComponent<Button>().interactable = false;
			GameObject.Find("Answer 2").GetComponent<Button>().interactable = false;
			GameObject.Find("Answer 3").GetComponent<Button>().interactable = false;
			GameObject.Find("Answer 4").GetComponent<Button>().interactable = false;
			await Task.Delay(5000);
			GameObject.Find("Answer 1").GetComponent<Button>().interactable = true;
			GameObject.Find("Answer 2").GetComponent<Button>().interactable = true;
			GameObject.Find("Answer 3").GetComponent<Button>().interactable = true;
			GameObject.Find("Answer 4").GetComponent<Button>().interactable = true;
		}

		public void answer1Pressed()
		{
			if(answer1.text == texts[questionId, 1])
			{
				GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			}
			else
			{
				GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = Color.red;
				GameObject.Find("Answer " + correctPos).GetComponent<UnityEngine.UI.Image>().color = Color.green;
			}
			
			nextQuestion();
		}

		public void answer2Pressed()
		{
			if(answer2.text == texts[questionId, 1])
			{
				GameObject.Find("Answer 2").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			}
			else
			{
				GameObject.Find("Answer 2").GetComponent<UnityEngine.UI.Image>().color = Color.red;
				GameObject.Find("Answer " + correctPos).GetComponent<UnityEngine.UI.Image>().color = Color.green;
			}

			nextQuestion();
		}

		public void answer3Pressed()
		{
			if(answer3.text == texts[questionId, 1])
			{
				GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			}
			else
			{
				GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.red;
				GameObject.Find("Answer " + correctPos).GetComponent<UnityEngine.UI.Image>().color = Color.green;
			}

			nextQuestion();
		}

		public void answer4Pressed()
		{
			if(answer4.text == texts[questionId, 1])
			{
				GameObject.Find("Answer 4").GetComponent<UnityEngine.UI.Image>().color = Color.green;
			}
			else
			{
				GameObject.Find("Answer 4").GetComponent<UnityEngine.UI.Image>().color = Color.red;
				GameObject.Find("Answer " + correctPos).GetComponent<UnityEngine.UI.Image>().color = Color.green;
			}

			nextQuestion();
		}

		public async void nextQuestion()
		{
			await PutTaskDelay();

			Color colors = new Color32(71, 65, 131, 255);
			GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = colors;
			GameObject.Find("Answer 2").GetComponent<UnityEngine.UI.Image>().color = colors;
			GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = colors;
			GameObject.Find("Answer 4").GetComponent<UnityEngine.UI.Image>().color = colors;

			++questionId;

			if(texts.GetLength(0) >= questionId)
			{
				loadQuestion(questionId);
			} 
			else
			{
				//switch to some other screen
			}
		}

		public void loadQuestion(int i){
			System.Random random = new System.Random();
			var numbers = Enumerable.Range(1, 4);
			var shuffle = numbers.OrderBy(a => random.NextDouble());

			int[] n = new int[5];
			int j = 0;
			
			foreach(var num in shuffle)
			{
				if(num == 1)
				{
					correctPos = j + 1;
				}

				n[j] = num;
				++j;
			}

			question.text = texts[i, 0];
			answer1.text = texts[i, n[0]];
			answer2.text = texts[i, n[1]];
			answer3.text = texts[i, n[2]];
			answer4.text = texts[i, n[3]];
		}

	}
}