using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Rituals : MonoBehaviour {

    public GameObject SequenceInfo;

    public int MaxSequenceLength = 6;

    public int[] RuneSequenceA;
    public int[] RuneSequenceB;
    public int[] RuneSequenceC;
    public int[] RuneSequenceD;
    public int[] RuneSequenceActive;

    public GameObject[] Runes;
	public GameObject Panel;
    private string disaster;
    private int i = 0;
    // Use this for initialization
    void Start() {
        for (int j = 0; j < 2; j++)
        {
            RuneSequenceA[j] = Random.Range(1, 5);
            RuneSequenceB[j] = Random.Range(1, 5);
            RuneSequenceC[j] = Random.Range(1, 5);
            RuneSequenceD[j] = Random.Range(1, 5);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public void StormIsComing()
    {       
        i = 0;
        disaster = "Storm";
        Debug.Log("StormSigns");
        GetComponent<TextFade>().FadeTo(false);
        GetComponent<TextFade>().DisInfo.GetComponent<Text>().text = disaster + " !";
        Color temp = GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color;
        temp.a = 0.0f;
        GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color = temp;
    }

    public void MosquitosAreComing()
    {
        i = 0;
        disaster = "Mosquitos";
        Debug.Log("MosquitosSigns");
        GetComponent<TextFade>().FadeTo(false);
        GetComponent<TextFade>().DisInfo.GetComponent<Text>().text = disaster + " !";
        Color temp = GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color;
        temp.a = 0.0f;
        GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color = temp;
    }

    public void FloodIsComing()
    {
        i = 0;
        disaster = "Flood";
        Debug.Log("FloodSigns");
        GetComponent<TextFade>().FadeTo(false);
        GetComponent<TextFade>().DisInfo.GetComponent<Text>().text = disaster + " !";
        Color temp = GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color;
        temp.a = 0.0f;
        GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color = temp;
    }

    public void HeatIsComing()
    {
        i = 0;
        disaster = "Heat";
        Debug.Log("HeatSigns");
        GetComponent<TextFade>().FadeTo(false);
        GetComponent<TextFade>().DisInfo.GetComponent<Text>().text = disaster + " !";
        Color temp = GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color;
        temp.a = 0.0f;
        GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color = temp;
    }





    public void RunePressed1()
    {
        if(RuneSequenceActive.Length > i && RuneSequenceActive[i] == 1)
        {
			Panel.GetComponent<RuneDrop>().Drop(1);
            i++;
            Debug.Log("Correct");  
        }
        else
        {
            Debug.Log("The rune is a lie");
        }
        if(RuneSequenceActive.Length == i)
        {
            GetComponent<Disasters>().Ritual_done = true;
            SequenceExpand();
        }
    }

    public void RunePressed2()
    {
        if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 2)
        {
			Panel.GetComponent<RuneDrop>().Drop(2);
            i++;
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("The rune is a lie");
        }
        if (RuneSequenceActive.Length == i)
        {
            GetComponent<Disasters>().Ritual_done = true;
            SequenceExpand();
        }
    }

    public void RunePressed3()
    {
        if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 3)
        {
			Panel.GetComponent<RuneDrop>().Drop(3);
            i++;
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("The rune is a lie");
        }
        if (RuneSequenceActive.Length == i)
        {
            GetComponent<Disasters>().Ritual_done = true;
            SequenceExpand();
        }
    }

    public void RunePressed4()
    {
        if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 4)
        {
			Panel.GetComponent<RuneDrop>().Drop(4);
            i++;
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("The rune is a lie");
        }
        if (RuneSequenceActive.Length == i)
        {
            GetComponent<Disasters>().Ritual_done = true;
            SequenceExpand();
        }
    }

    public void RunePressedA()
    {
        if (disaster == "Storm")
        {
            RuneSequenceActive = RuneSequenceA;
            SequenceTextChange();
        }
        else
        {
            Debug.Log("Wrong Button Fag");
        }
        
    }

    public void RunePressedB()
    {
        if (disaster == "Mosquitos")
        {
            RuneSequenceActive = RuneSequenceB;
            SequenceTextChange();
        }
        else
        {
            Debug.Log("Wrong Button Fag");
        }
    }

    public void RunePressedC()
    {
        if (disaster == "Flood")
        {
            RuneSequenceActive = RuneSequenceC;
            SequenceTextChange();
        }
        else
        {
            Debug.Log("Wrong Button Fag");
        }
    }

    public void RunePressedD()
    {
        if (disaster == "Heat")
        {
            RuneSequenceActive = RuneSequenceD;
            SequenceTextChange();
        }
        else
        {
            Debug.Log("Wrong Button Fag");
        }
    }

    public void SequenceTextChange()
    {
        Color temp = GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color;
        temp.a = 1.0f;
        GetComponent<TextFade>().SequenceInfo.GetComponent<Text>().color = temp;
        GetComponent<TextFade>().FadeTo(true);
        SequenceInfo.GetComponent<Text>().text = " ";
        for (int j = 0; j < RuneSequenceActive.Length; j++)
        {
            SequenceInfo.GetComponent<Text>().text += RuneSequenceActive[j] + " ";
        }
    }

    public void SequenceExpand()
    {
        GetComponent<Disasters>().StartCoroutine("start_disaster");
        GetComponent<Disasters>().Ritual_done = false;
        switch (disaster)
        {
            case "Storm":
                if(RuneSequenceA.Length < MaxSequenceLength)
                {
                    RuneSequenceA = ExpandArray(RuneSequenceA);
                }  
                break;
            case "Mosquitos":
                if (RuneSequenceB.Length < MaxSequenceLength)
                {
                    RuneSequenceB = ExpandArray(RuneSequenceB);
					
                }
                break;
            case "Flood":
                if (RuneSequenceC.Length < MaxSequenceLength)
                {
                    RuneSequenceC = ExpandArray(RuneSequenceC);
					
                }
                break;
            case "Heat":
                if (RuneSequenceD.Length < MaxSequenceLength)
                {
                    RuneSequenceD = ExpandArray(RuneSequenceD);
					
                }
                break;
        }
		Panel.GetComponent<RuneDrop> ().runes_index = 0;
    }

    int[] ExpandArray(int[] A)
    {
        int[] Temp = new int[A.Length +1];
        for(int j = 0; j < A.Length; j++)
        {
            Temp[j] = A[j];
        }
        Temp[A.Length] = Random.Range(1, 5);
        return Temp;
    }

    public void ResetRunes()
    {
        for (int j = 0; j < Runes.Length; j++)
        {
            Runes[j].SetActive(false);
        }
    }
}