using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFont : MonoBehaviour {

    public int chFont;
    Toggle m_Toggle;

    // Use this for initialization
    void Start () {
        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();
        if (PlayerPrefs.GetInt("ChFont", 0) == 0)
        {
            m_Toggle.isOn = false;
        }
        else
        {
            m_Toggle.isOn = true;
        }
        //Add listener for when the state of the Toggle changes, to take action
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
        });
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        chFont = m_Toggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("ChFont", chFont);
        PlayerPrefs.Save();
    }
}
