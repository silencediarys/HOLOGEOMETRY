using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TYKSecondScreenHandler : MonoBehaviour
{

	float timeLeft = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
      System.Threading.Thread.Sleep(1000);
      timeLeft -= 1;
      if(timeLeft == 0)
      {
        print("Time's up!");
        

      }
      //print(timeLeft);
    }
}
