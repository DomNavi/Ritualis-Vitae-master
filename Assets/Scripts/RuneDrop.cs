using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RuneDrop : MonoBehaviour {

	public GameObject[] GuessedRunes;
	public Sprite[] RunesIcons;
	public int runes_index = 0;
    private int tempIndex;
    public float yVelocity = 80.0f;
    private Vector3[] StartPos = new Vector3[6];
    private Vector3[] tmp = new Vector3[6];

    void Start()
    {      
        for(int i = 0; i < 6; i++)
        {
            StartPos[i] = GuessedRunes[i].GetComponent<RectTransform>().position;
            tmp[i] = GuessedRunes[i].GetComponent<RectTransform>().position;
        }
        //Drop(1);
    }

    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if(tmp[i].y >= StartPos[i].y)
            {
                tmp[i].y = Mathf.SmoothDamp(tmp[i].y, StartPos[i].y, ref yVelocity, 2.2f * Time.deltaTime);
                GuessedRunes[i].GetComponent<RectTransform>().position = new Vector3(tmp[i].x, tmp[i].y, tmp[i].z);
            }           
        }
        
    }

	public void Drop(int RuneIcon)
    {
        tmp[runes_index] = new Vector3(tmp[runes_index].x, 70.0f, tmp[runes_index].z);
        GuessedRunes[runes_index].SetActive(true);
		GuessedRunes [runes_index].GetComponent<Image> ().sprite = RunesIcons[RuneIcon-1];
		runes_index++;
    }
}
