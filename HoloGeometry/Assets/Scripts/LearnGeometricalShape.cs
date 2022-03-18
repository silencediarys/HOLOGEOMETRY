using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI{
    public class LearnGeometricalShape : MonoBehaviour
    {

        private Button choosenShape;
        private bool click = false;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void selectShape(Button button)
        {
            // All button objects are saved in variables
            Button selectShapeButton =  GameObject.Find("SelectShapeButton").GetComponent<Button>();
            Button leftButton =  GameObject.Find("LeftButton").GetComponent<Button>();
            Button middleButton =  GameObject.Find("MiddleButton").GetComponent<Button>();
            Button rightButton =  GameObject.Find("RightButton").GetComponent<Button>();

            // Color of all buttons is reseted
            Color colors = new Color32(71, 65, 131, 255);
            leftButton.GetComponentInChildren<Image>().color = colors;
            middleButton.GetComponentInChildren<Image>().color = colors;
            rightButton.GetComponentInChildren<Image>().color = colors;
            
            // Button when pressed changes color to blue ( could be changed to any color in fututre )
            button.GetComponentInChildren<Image>().color = new Color32(0, 0, 255, 255);;

            // Button to select shape is enabled to be used
            selectShapeButton.interactable = true;

            // Shape that was selected is saved in this variable
            // Button object is saved!!!
            choosenShape = button;
        }

        public void timer(UIScreen screen)
        {
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

                fillThirdScreen();
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

        public void fillThirdScreen()
        {   
            // This part should be finished when we figure out how we are going to make holograms.
            // Right now I have just changed text of description to tell which shape has been selected.
            // We also need better description, audio description, change color functionality and we need to be able to rotate and zoom hologram
            // But I wasn't sure how we are going to do hologram stuff
            if(choosenShape.name == "LeftButton")
            {
                GameObject.Find("Description").GetComponentInChildren<Text>().text = "Pyramid";
            }
            else if(choosenShape.name == "MiddleButton")
            {
                GameObject.Find("Description").GetComponentInChildren<Text>().text = "Square";
            }
            else if(choosenShape.name == "RightButton")
            {
                GameObject.Find("Description").GetComponentInChildren<Text>().text = "Cylinder";
            }
        }
    }

}
