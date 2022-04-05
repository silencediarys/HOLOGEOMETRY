using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hologram : MonoBehaviour {
    [Header("Settings")]

    private float sliderRotPos, lastRotPos = 0, sliderSizePos, lastSizePos = 0, baseScale;
    private Slider rotation, size;
    
    void Start()
    {
        rotation = GameObject.Find("Rotation").GetComponent<Slider>();
        size = GameObject.Find("Size").GetComponent<Slider>();

        sliderRotPos = rotation.value;
        sliderSizePos = size.value;
        baseScale = this.transform.localScale.x;
    }

	public void rotate()
    {
        sliderRotPos = rotation.value;

        if(sliderRotPos > lastRotPos)
        {
            this.transform.Rotate(transform.position.x, 10.0f, transform.position.z);
        }
        else
        {
            this.transform.Rotate(transform.position.x, -10.0f, transform.position.y);
        }

        lastRotPos = rotation.value;
	}

    public void scale()
    {   
        this.transform.localScale = new Vector3(size.value + baseScale, size.value + baseScale, size.value + baseScale);

        sliderSizePos = size.value;

        if(sliderSizePos > lastSizePos)
        {
            
            this.transform.position += transform.up * (size.value * (float)0.08);
        }
        else
        {
            this.transform.position += transform.up * -(size.value * (float)0.08);
        }

        
        lastSizePos = size.value;
    }

    public void changeColor(Button btn)
    {
        GameObject.Find(PlayerPrefs.GetString("shape")).GetComponent<Renderer>().material.SetColor("_Color", btn.GetComponentInChildren<Image>().color);
    }
}
