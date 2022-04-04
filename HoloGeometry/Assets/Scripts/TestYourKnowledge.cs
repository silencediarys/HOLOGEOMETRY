using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI 
{
    public class TestYourKnowledge : MonoBehaviour
    {

        private bool click = false;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void timer(UIScreen screen)
        {
            Quiz.questionId = 0;
            Quiz.correct_count = 0;
            Quiz.wrong_count = 0;
            StartCoroutine(wait(screen));
        }

        IEnumerator wait(UIScreen screen)
        {
            // Reseting click
            click = false;

            // Countdown
            GameObject.Find("TimerButton").GetComponentInChildren<Text>().text = "Timer: 5";
            yield return new WaitForSeconds(1);
            GameObject.Find("TimerButton").GetComponentInChildren<Text>().text = "Timer: 4";
            yield return new WaitForSeconds(1);
            GameObject.Find("TimerButton").GetComponentInChildren<Text>().text = "Timer: 3";
            yield return new WaitForSeconds(1);
            GameObject.Find("TimerButton").GetComponentInChildren<Text>().text = "Timer: 2";
            yield return new WaitForSeconds(1);
            GameObject.Find("TimerButton").GetComponentInChildren<Text>().text = "Timer: 1";
            yield return new WaitForSeconds(1);
            GameObject.Find("TimerButton").GetComponentInChildren<Text>().text = "Timer: 0";

            // If click == true switch screens, else do notihing
            if(!click)
            {
                // I have made SwithScreens method static and few variables because if I created an object of UISystem here to call the method I would encounter problems
                // By making these method and variables static you can call them without creating an object of UISystem
                UISystem.SwitchScreens(screen);
            }
        }

        // This method is called when you press back button in SecondScreen
        // The problem was: although back button was pressed and screen would have changed to previous ( to the first screen )
        // the method timer would still run in background and after timer ends the screen would change to thrid
        // with this method when back button is pressed click variable is set to true and in the method above the screen wouldn't change
        public void resetTimer()
        {
            click = true;
        }
    }

}
