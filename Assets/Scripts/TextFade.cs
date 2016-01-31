using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFade : MonoBehaviour {

    public GameObject SequenceInfo;
    //public GameObject DisInfo;
    private bool fade = true;
    private Color Temp;

    // Use this for initialization
    void Start () {
        Temp = new Color (252f / 255f, 160f / 255f, 6f / 255f);
    }

    void Update()
    {
        if (fade)
        {
            Temp.a = Mathf.Lerp(Temp.a, 0.0f, 8.5f * Time.deltaTime);
            //DisInfo.GetComponent<Text>().color = Temp;
        }
        else
        {
            Temp.a = Mathf.Lerp(Temp.a, 1.0f, 8.5f * Time.deltaTime);
            //DisInfo.GetComponent<Text>().color = Temp;            
        }

    }

    public void FadeTo(bool fading)
    {
        fade = fading;
    }
	
    
}
