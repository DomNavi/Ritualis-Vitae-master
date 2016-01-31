﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Rituals : MonoBehaviour {

    public GameObject SequenceInfo;

    public int MaxSequenceLength = 6;
    public GameObject RitualHit;
    public int[] RuneSequenceA;
    public int[] RuneSequenceB;
    public int[] RuneSequenceC;
    public int[] RuneSequenceD;
    public int[] RuneSequenceActive;
    public GameObject TimeText;

    public GameObject[] Runes;
	public GameObject Panel;
    private string disaster;
    private int i = 0;
    private float timeDiff = 6;

    public Sprite[] RunesIcons = new Sprite[4];

    public bool RitualInProgress = false;
        
    public GameObject SequenceInfoGrid;
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
        TimeText.GetComponent<Text>().text = Mathf.CeilToInt(timeDiff - Time.time).ToString();

    }

    public void StormIsComing()
    {
        timeDiff = Time.time + 6;
        TimeText.SetActive(true);
        disaster = "Storm";
        Debug.Log("StormSigns");
        GetComponent<TextFade>().FadeTo(false);
        GetComponent<TextFade>().DisInfo.GetComponent<Text>().text = disaster + " !";
        ResetRunes();
    }

    public void MosquitosAreComing()
    {
        timeDiff = Time.time + 6;
        TimeText.SetActive(true);
        disaster = "Mosquitos";
        Debug.Log("MosquitosSigns");
        GetComponent<TextFade>().FadeTo(false);
        GetComponent<TextFade>().DisInfo.GetComponent<Text>().text = disaster + " !";
        ResetRunes();
    }

    public void FloodIsComing()
    {
        timeDiff = Time.time + 6;
        TimeText.SetActive(true);
        disaster = "Flood";
        Debug.Log("FloodSigns");
        GetComponent<TextFade>().FadeTo(false);
        GetComponent<TextFade>().DisInfo.GetComponent<Text>().text = disaster + " !";
        ResetRunes();
    }

    public void HeatIsComing()
    {
        timeDiff = Time.time + 6;
        TimeText.SetActive(true);
        disaster = "Heat";
        Debug.Log("HeatSigns");
        GetComponent<TextFade>().FadeTo(false);
        GetComponent<TextFade>().DisInfo.GetComponent<Text>().text = disaster + " !";      
		ResetRunes ();
    }


    public void RunePressed1()
    {
        if (RitualInProgress)
        {
            if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 1)
            {
                Panel.GetComponent<RuneDrop>().Drop(1);
                i++;
                RitualHit.GetComponent<ParticleSystem>().Emit(30);
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("The rune is a lie");
            }
            if (RuneSequenceActive.Length == i)
            {
                TimeText.SetActive(false);
                RitualInProgress = false;
                i = 0;
                GetComponent<Disasters>().Ritual_done++;
                SequenceExpand();
            }
        }
        
    }

    public void RunePressed2()
    {
        if (RitualInProgress)
        {
            if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 2)
            {
                Panel.GetComponent<RuneDrop>().Drop(2);
                i++;
                RitualHit.GetComponent<ParticleSystem>().Emit(30);
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("The rune is a lie");
            }
            if (RuneSequenceActive.Length == i)
            {
                TimeText.SetActive(false);
                RitualInProgress = false;
                i = 0;
                GetComponent<Disasters>().Ritual_done++;
                SequenceExpand();
            }
        }
       
    }

    public void RunePressed3()
    {
        if (RitualInProgress)
        {
            if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 3)
            {
                Panel.GetComponent<RuneDrop>().Drop(3);
                i++;
                RitualHit.GetComponent<ParticleSystem>().Emit(30);
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("The rune is a lie");
            }
            if (RuneSequenceActive.Length == i)
            {
                TimeText.SetActive(false);
                RitualInProgress = false;
                i = 0;
                GetComponent<Disasters>().Ritual_done++;
                SequenceExpand();
            }
        }
        
    }

    public void RunePressed4()
    {
       if(RitualInProgress) {
            if (RuneSequenceActive.Length > i && RuneSequenceActive[i] == 4)
            {
                Panel.GetComponent<RuneDrop>().Drop(4);
                i++;
                RitualHit.GetComponent<ParticleSystem>().Emit(30);
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("The rune is a lie");
            }
            if (RuneSequenceActive.Length == i)
            {
                TimeText.SetActive(false);
                RitualInProgress = false;
                i = 0;
                GetComponent<Disasters>().Ritual_done++;
                SequenceExpand();
            }
        }
       
    }

    public void RunePressedA()
    {
        if (disaster == "Storm" && !RitualInProgress)
        {
            //i = 0;
            RitualInProgress = true;
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
        if (disaster == "Mosquitos" && !RitualInProgress)
        {
            //i = 0;
            RitualInProgress = true;
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
        if (disaster == "Flood" && !RitualInProgress)
        {
            //i = 0;
            RitualInProgress = true;
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
        if (disaster == "Heat" && !RitualInProgress)
        {
            //i = 0;
            RitualInProgress = true;
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
        //GetComponent<TextFade>().FadeTo(true);
        for (int j = 0; j < RuneSequenceActive.Length; j++)
        {
            SequenceInfoGrid.GetComponent<SequenceGrid>().SequenceElements[j].SetActive(true);
            SequenceInfoGrid.GetComponent<SequenceGrid>().SequenceElements[j].GetComponent<Image>().sprite = RunesIcons[RuneSequenceActive[j]-1];
        }
        //SequenceInfo.GetComponent<Text>().text = " ";
        //for (int k = 0; k < RuneSequenceActive.Length; k++)
        //{
        //    SequenceInfo.GetComponent<Text>().text += RuneSequenceActive[k] + " ";
        //}
    }

    public void SequenceExpand()
    {
        timeDiff = Time.time + 6;
        for (int j = 0; j < RuneSequenceActive.Length; j++)
        {
            SequenceInfoGrid.GetComponent<SequenceGrid>().SequenceElements[j].SetActive(false);
        }

        GetComponent<Disasters>().StartCoroutine("start_disaster");

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