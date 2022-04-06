using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace UI
{
    public class RecognizeGeometricalShapes : MonoBehaviour
    {   
        private int questionId = 0, correctPos;
        private Text shape1, shape2, shape3, shape4;
        private string[] shapes = { "Cube", "Cylinder", "Pyramid", "Sphere" };
        private UIScreen correct, wrong, rgs;
        private int[] shuffle;

        // Start is called before the first frame update
        void Start()
        {
            shape1 = GameObject.Find("Shape 1").GetComponentInChildren<UnityEngine.UI.Text>();
            shape2 = GameObject.Find("Shape 2").GetComponentInChildren<UnityEngine.UI.Text>();
            shape3 = GameObject.Find("Shape 3").GetComponentInChildren<UnityEngine.UI.Text>();
            shape4 = GameObject.Find("Shape 4").GetComponentInChildren<UnityEngine.UI.Text>();

            correct = GameObject.Find("CorrectScreen").GetComponent<UI.UIScreen>();
            wrong = GameObject.Find("WrongScreen").GetComponent<UI.UIScreen>();
            rgs = GameObject.Find("FirstScreen").GetComponent<UI.UIScreen>();

            System.Random random = new System.Random();
            var numbers = Enumerable.Range(0, 4);
            shuffle = numbers.OrderBy(a => random.NextDouble()).ToArray();

            loadShape(shuffle[questionId]);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void nextShape()
        {
            ++questionId;

			if(shapes.GetLength(0) > questionId)
			{
                UI.UISystem.SwitchScreens(rgs);
				loadShape(shuffle[questionId]);
			} 
			else
			{
				
			}
        }

        public void loadShape(int i)
        {
            System.Random random = new System.Random();
            var n = Enumerable.Range(0, 4);
            var shuffle_x = n.OrderBy(a => random.NextDouble()).ToArray();
            
            PlayerPrefs.SetString("shape", shapes[i]);
            PlayerPrefs.Save();

            hideShapes();

            GameObject.Find(shapes[i]).GetComponent<Renderer>().enabled = true;

            shape1.text = shapes[shuffle[shuffle_x[0]]];
            shape2.text = shapes[shuffle[shuffle_x[1]]];
            shape3.text = shapes[shuffle[shuffle_x[2]]];
            shape4.text = shapes[shuffle[shuffle_x[3]]];
        }

        public void hideShapes(){
            GameObject.Find("Cylinder").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Sphere").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Cube").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Pyramid").GetComponent<Renderer>().enabled = false;
        }

        public void answer1Pressed()
        {
            if(shape1.text == shapes[shuffle[questionId]])
            {
                UI.UISystem.SwitchScreens(correct);
            }
            else
            {
                UI.UISystem.SwitchScreens(wrong);
            }
        }

        public void answer2Pressed()
        {
            if(shape2.text == shapes[shuffle[questionId]])
            {
                UI.UISystem.SwitchScreens(correct);
            }
            else
            {
                UI.UISystem.SwitchScreens(wrong);
            }
        }

        public void answer3Pressed()
        {
            if(shape3.text == shapes[shuffle[questionId]])
            {
                UI.UISystem.SwitchScreens(correct);
            }
            else
            {
                UI.UISystem.SwitchScreens(wrong);
            }
        }

        public void answer4Pressed()
        {
            if(shape4.text == shapes[shuffle[questionId]])
            {
                UI.UISystem.SwitchScreens(correct);
            }
            else
            {
                UI.UISystem.SwitchScreens(wrong);
            }
        }
    }

}