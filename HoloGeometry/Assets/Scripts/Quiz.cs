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
	public class Quiz : MonoBehaviour
	{
		public static int number_of_questions = 10;

		public String[,] texts;
		public Text question;
		public Text correct_answer;
		public Text answer2;
		public Text answer3;
		public Text answer4;
		public Text correct_text;
		public Text wrong_text;
		public Text percentage_text;
		public static int questionId;
		private int correctPos;
		private UIScreen statisticsScreen;
		public static int correct_count;
		public static int wrong_count;

		public static int[] shuffle;

		void Start()
        {
			statisticsScreen = GameObject.Find("StatisticsScreen").GetComponent<UI.UIScreen>();
			correct_text = GameObject.Find("CorrectText").GetComponent<UnityEngine.UI.Text>();
			wrong_text = GameObject.Find("WrongText").GetComponent<UnityEngine.UI.Text>();
			percentage_text = GameObject.Find("PercentageText").GetComponent<UnityEngine.UI.Text>();

			// Initializing all questions
			question = GameObject.Find("Question").GetComponentInChildren<UnityEngine.UI.Text>();
			correct_answer = GameObject.Find("Answer 1").GetComponentInChildren<UnityEngine.UI.Text>();
			answer2 = GameObject.Find("Answer 2").GetComponentInChildren<UnityEngine.UI.Text>();
			answer3 = GameObject.Find("Answer 3").GetComponentInChildren<UnityEngine.UI.Text>();
			answer4 = GameObject.Find("Answer 4").GetComponentInChildren<UnityEngine.UI.Text>();

			texts = new String[number_of_questions, 5];

            texts[0, 0] = "What kind of faces does a cube have?";
            texts[0, 1] = "Square";
            texts[0, 2] = "Circle";
            texts[0, 3] = "Triangle";
			texts[0, 4] = "Pentagon";

			texts[1, 0] = "What shape has 8 vertices?";
            texts[1, 1] = "Octagon";
            texts[1, 2] = "Pentagon";
            texts[1, 3] = "Triangle";
			texts[1, 4] = "Hexagon";

			texts[2, 0] = "How many faces does a pyramid have?";
            texts[2, 1] = "5";
            texts[2, 2] = "3";
            texts[2, 3] = "4";
			texts[2, 4] = "6";

            texts[3, 0] = "What geometric body is bounded by 6 squares?";
            texts[3, 1] = "Cube";
            texts[3, 2] = "Sphere";
            texts[3, 3] = "Cylinder";
            texts[3, 4] = "Pyramid";

			texts[4, 0] = "Which geometric body has 2 flat and 1 curved surface?";
			texts[4, 1] = "Cylinder";
			texts[4, 2] = "Sphere";
			texts[4, 3] = "Cube";
			texts[4, 4] = "Pyramid";

			texts[5, 0] = "Which geometric body has no flat surfaces?";
			texts[5, 1] = "Sphere";
			texts[5, 2] = "Cube";
			texts[5, 3] = "Pyramid";
			texts[5, 4] = "Cylinder";

			texts[6, 0] = "Which geometric body has the shape of a ball?";
			texts[6, 1] = "Sphere";
			texts[6, 2] = "Pyramid";
			texts[6, 3] = "Cube";
			texts[6, 4] = "Cylinder";

			texts[6, 0] = "Which geometric body has 2 circles?";
			texts[6, 1] = "Cylinder";
			texts[6, 2] = "Pyramid";
			texts[6, 3] = "Cube";
			texts[6, 4] = "Sphere";

			texts[7, 0] = "Which geometric body has 1 square?";
			texts[7, 1] = "Pyramid";
			texts[7, 2] = "Cylinder";
			texts[7, 3] = "Cube";
			texts[7, 4] = "Sphere";

			texts[8, 0] = "Which geometric body has the shape of a dice?";
			texts[8, 1] = "Cube";
			texts[8, 2] = "Pyramid";
			texts[8, 3] = "Sphere";
			texts[8, 4] = "Cylinder";

			texts[9, 0] = "What shape has 5 vertices?";
			texts[9, 1] = "Pentagon";
			texts[9, 2] = "Octagon";
			texts[9, 3] = "Triangle";
			texts[9, 4] = "Hexagon";

			System.Random random = new System.Random();
			var numbers = Enumerable.Range(0, Quiz.number_of_questions);
			shuffle = numbers.OrderBy(a => random.NextDouble()).ToArray();

			loadQuestion(shuffle[questionId]);
        }

		public async Task PutTaskDelay()
		{
			GameObject.Find("Answer 1").GetComponent<Button>().interactable = false;
			GameObject.Find("Answer 2").GetComponent<Button>().interactable = false;
			GameObject.Find("Answer 3").GetComponent<Button>().interactable = false;
			GameObject.Find("Answer 4").GetComponent<Button>().interactable = false;

			await Task.Delay(1000);

			GameObject.Find("Answer 1").GetComponent<Button>().interactable = true;
			GameObject.Find("Answer 2").GetComponent<Button>().interactable = true;
			GameObject.Find("Answer 3").GetComponent<Button>().interactable = true;
			GameObject.Find("Answer 4").GetComponent<Button>().interactable = true;
		}

		public void answer1Pressed()
		{
			if(correct_answer.text == texts[shuffle[questionId], 1])
			{
				GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = Color.green;
				correct_count++;
			}
			else
			{
				GameObject.Find("Answer 1").GetComponent<UnityEngine.UI.Image>().color = Color.red;
				GameObject.Find("Answer " + correctPos).GetComponent<UnityEngine.UI.Image>().color = Color.green;
				wrong_count++;
			}
			
			nextQuestion();
		}

		public void answer2Pressed()
		{
			if(answer2.text == texts[shuffle[questionId], 1])
			{
				GameObject.Find("Answer 2").GetComponent<UnityEngine.UI.Image>().color = Color.green;
				correct_count++;
			}
			else
			{
				GameObject.Find("Answer 2").GetComponent<UnityEngine.UI.Image>().color = Color.red;
				GameObject.Find("Answer " + correctPos).GetComponent<UnityEngine.UI.Image>().color = Color.green;
				wrong_count++;
			}

			nextQuestion();
		}

		public void answer3Pressed()
		{
			if(answer3.text == texts[shuffle[questionId], 1])
			{
				GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.green;
				correct_count++;
			}
			else
			{
				GameObject.Find("Answer 3").GetComponent<UnityEngine.UI.Image>().color = Color.red;
				GameObject.Find("Answer " + correctPos).GetComponent<UnityEngine.UI.Image>().color = Color.green;
				wrong_count++;
			}

			nextQuestion();
		}

		public void answer4Pressed()
		{
			if(answer4.text == texts[shuffle[questionId], 1])
			{
				GameObject.Find("Answer 4").GetComponent<UnityEngine.UI.Image>().color = Color.green;
				correct_count++;
			}
			else
			{
				GameObject.Find("Answer 4").GetComponent<UnityEngine.UI.Image>().color = Color.red;
				GameObject.Find("Answer " + correctPos).GetComponent<UnityEngine.UI.Image>().color = Color.green;
				wrong_count++;
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

			if(texts.GetLength(0) > questionId)
			{
				loadQuestion(shuffle[questionId]);
			} 
			else
			{
				//switch to statistics screen
				UI.UISystem.SwitchScreens(statisticsScreen);
				correct_text.text = "Correct answers:    " + correct_count;
				wrong_text.text = "Wrong  answers:     " + wrong_count;
				percentage_text.text = "You were " + (((float)correct_count / (wrong_count + correct_count)) * 100).ToString("F2") + "% successful!";
			}
		}

		public void loadQuestion(int i) {
			System.Random random = new System.Random();
			var numbers = Enumerable.Range(1, 4);
			var shuffle_x = numbers.OrderBy(a => random.NextDouble());

			int[] n = new int[5];
			int j = 0;
			
			foreach(var num in shuffle_x)
			{
				if(num == 1)
				{
					correctPos = j + 1;
				}

				n[j] = num;
				++j;
			}

			question.text = texts[i, 0];
			correct_answer.text = texts[i, n[0]];
			answer2.text = texts[i, n[1]];
			answer3.text = texts[i, n[2]];
			answer4.text = texts[i, n[3]];
		}

	}
}