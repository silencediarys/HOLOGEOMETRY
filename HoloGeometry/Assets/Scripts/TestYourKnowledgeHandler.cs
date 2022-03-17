using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestYourKnowledgeHandler : MonoBehaviour
{
  //[SerializeField] private string scene;

  public GameObject SecondScreen;
  public GameObject AccessibilityScreen;


  public void OpenSecondScreen()
  {
    if(SecondScreen != null)
    {
      SecondScreen.SetActive(true);
    }
  }

  public void OpenPreviousPage()
  {
    SceneManager.LoadScene("Main Scene");
    if(AccessibilityScreen != null)
    {
      AccessibilityScreen.SetActive(true);
    }
  }

  public void OpenAccessibility()
  {
    if(SecondScreen != null)
    {
      SecondScreen.SetActive(true);
    }
  }
}
