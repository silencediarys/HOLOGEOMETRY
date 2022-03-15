using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestYourKnowledgeHandler : MonoBehaviour
{
  //[SerializeField] private string scene;

  public GameObject SecondScreen;

  public void OpenSecondScreen()
  {
    if(SecondScreen != null)
    {
      SecondScreen.SetActive(true);
    }
  }
}
