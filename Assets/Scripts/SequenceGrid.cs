using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SequenceGrid : MonoBehaviour {


    public GameObject[] SequenceElements = new GameObject[6];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < SequenceElements.Length; i++)
        {
            if (SequenceElements[i].activeSelf)
            {
                Color tmp = SequenceElements[i].GetComponent<Image>().color;
                tmp.a = Mathf.Lerp(tmp.a, 1.0f, 9.5f * Time.deltaTime);
                SequenceElements[i].GetComponent<Image>().color = tmp;
            }
            else
            {
                Color tmp = SequenceElements[i].GetComponent<Image>().color;
                tmp.a = Mathf.Lerp(tmp.a, 0.0f, 8.5f * Time.deltaTime);
                SequenceElements[i].GetComponent<Image>().color = tmp;
            }
        }
	    
	}

}
