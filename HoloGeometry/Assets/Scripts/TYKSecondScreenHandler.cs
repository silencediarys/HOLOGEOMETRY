using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TYKSecondScreenHandler : MonoBehaviour
{

  public GameObject Question1;

  float timeLeft = 5;

    public void OpenQuestion1()          
    {
      if(Question1 != null)
      {
        Question1.SetActive(true);
      }
    }

    // Update is called once per frame
    void Update()
    {
      
      System.Threading.Thread.Sleep(1000);
      timeLeft -= 1;
      if(timeLeft <= 0)
      {
          OpenQuestion1();
      }
      GameObject.Find("TimerButton").GetComponentInChildren<Text>().text = string.Format("Timer: {0}", timeLeft);
    }
}
