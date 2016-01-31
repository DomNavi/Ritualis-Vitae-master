using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFade : MonoBehaviour {

    public GameObject SequenceInfo;
    public GameObject DisInfo;
    private bool fade = true;
    private Color Temp;

    // Use this for initialization
    void Start () {
        Temp = SequenceInfo.GetComponent<Text>().color;
    }

    void Update()
    {
        if (fade)
        {
            Temp.a = Mathf.Lerp(Temp.a, 0.0f, 8.5f * Time.deltaTime);
            //SequenceInfo.GetComponent<Text>().color = Temp;
            DisInfo.GetComponent<Text>().color = Temp;
        }
        else
        {
            Temp.a = Mathf.Lerp(Temp.a, 1.0f, 8.5f * Time.deltaTime);
            //SequenceInfo.GetComponent<Text>().color = Temp;
            DisInfo.GetComponent<Text>().color = Temp;            
        }

    }

    public void FadeTo(bool fading)
    {
        fade = fading;
    }
	
    
}
