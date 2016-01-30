using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RuneDrop : MonoBehaviour {

	public GameObject[] GuessedRunes;
	public Sprite[] RunesIcons;
	public int runes_index = 0;
    Vector3 pos;
    public float yVelocity = 80.0f;

    void Start()
    {

		Debug.Log (GuessedRunes.Length);
		pos = GuessedRunes[runes_index].GetComponent<RectTransform>().position;
		Debug.Log (pos);
        //Drop(1);
    }

    void Update()
    {
        //pos.y = Mathf.SmoothDamp(pos.y, 34.35f, ref yVelocity, 0.2f);
		//GuessedRunes[runes_index].GetComponent<RectTransform>().position = pos;
    }

	public void Drop(int RuneIcon)
    {
        pos.y = 70.0f;
		Debug.Log (GuessedRunes.Length);
		//Color tmp = GuessedRunes[runes_index].GetComponent<Image>().color

		//GuessedRunes[runes_index].GetComponent<Image>().color = new Color(1,1,1,1);
		GuessedRunes[runes_index].SetActive(true);
		GuessedRunes [runes_index].GetComponent<Image> ().sprite = RunesIcons[RuneIcon-1];
		runes_index++;

    }
}
