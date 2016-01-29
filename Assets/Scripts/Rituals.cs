using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Rituals : MonoBehaviour {

    public GameObject SequenceInfo;

    public int[] RuneSequenceA;
    public int[] RuneSequenceB;
    public int[] RuneSequenceC;
    public int[] RuneSequenceD;
    public int[] RuneSequenceActive;

    private string disaster;
    private int i = 0;
    // Use this for initialization
    void Start() {
        disaster = "Storm";
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
        disaster = "Storm";
        Debug.Log("StormSigns");
    }

    public void MosquitosAreComing()
    {
        disaster = "Mosquitos";
        Debug.Log("MosquitosSigns");
    }

    public void FloodIsComing()
    {
        disaster = "Flood";
        Debug.Log("FloodSigns");
    }

    public void HeatIsComing()
    {
        disaster = "Heat";
        Debug.Log("HeatSigns");
    }





    public void RunePressed1()
    {
        if(RuneSequenceActive.Length > i && RuneSequenceActive[i] == 1)
        {
            i++;
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("The rune is a lie");
        }
        if(RuneSequenceActive.Length == i)
        {
           // GetComponent<Disasters>().Ritual_done = true;
        }
    }

    public void RunePressed2()
    {
        if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 2)
        {
            i++;
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("The rune is a lie");
        }
        if (RuneSequenceActive.Length == i)
        {
            // GetComponent<Disasters>().Ritual_done = true;
        }
    }

    public void RunePressed3()
    {
        if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 3)
        {
            i++;
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("The rune is a lie");
        }
        if (RuneSequenceActive.Length == i)
        {
            // GetComponent<Disasters>().Ritual_done = true;
        }
    }

    public void RunePressed4()
    {
        if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 4)
        {
            i++;
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("The rune is a lie");
        }
        if (RuneSequenceActive.Length == i)
        {
            // GetComponent<Disasters>().Ritual_done = true;
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
        SequenceInfo.GetComponent<Text>().text = " ";
        for (int j = 0; j < RuneSequenceActive.Length; j++)
        {
            SequenceInfo.GetComponent<Text>().text += RuneSequenceActive[j] + " ";
        }
    }
}