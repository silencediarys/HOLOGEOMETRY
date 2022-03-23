using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFont : MonoBehaviour {

    Text m_text;
    public int _fontSizeD;
    public int _fontSizeR;
    public Font _regular;
    public Font _dyslexic;
    public int f;


	// Use this for initialization
	void Start () {
        f = PlayerPrefs.GetInt("ChFont");
        m_text = GetComponent<Text>();
        if (f == 1)
        {
            m_text.font = _dyslexic;
            m_text.fontSize = _fontSizeD;
        }
        else
        {
            m_text.font = _regular;
            m_text.fontSize = _fontSizeR;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        f = PlayerPrefs.GetInt("ChFont");
        m_text = GetComponent<Text>();
        if (f == 1)
        {
            m_text.font = _dyslexic;
            m_text.fontSize = _fontSizeD;
        }
        else
        {
            m_text.font = _regular;
            m_text.fontSize = _fontSizeR;
        }

    }
}
