using UnityEngine;
using System.Collections;

public class Disasters : MonoBehaviour {
	public string[] Disasters_list = {"storm","mosquitos","flood","heat"};
	public string Current_disaster;
	public bool Ritual_done = false;
	// Use this for initialization
	void Start () {
		
		StartCoroutine (wait_for_disaster());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator wait_for_disaster(){
		yield return new WaitForSeconds (4);
		Debug.Log ("Disaster started");
		StartCoroutine (start_disaster ());
	}
	IEnumerator start_disaster(){
		Current_disaster =Disasters_list[Random.Range(0,Disasters_list.Length)];
		switch (Current_disaster) {
			case "storm":
				Debug.Log ("Brace yourself, storm is coming!");
				//GetComponent<Rituals>().StormIsComing ();
				break;
			case "mosquitos":
				Debug.Log ("Mosquitos are heading your way!");
				//GetComponent<Rituals>().MosquitosAreComing ();
				break;
			case "flood":
				Debug.Log ("Water is rising!");
				//GetComponent<Rituals>().FloodIsComing ();
				break;
			case "heat":
				Debug.Log ("Its getting hot!");
				//GetComponent<Rituals>().HeatIsComing ();
				break;
		}
		yield return new WaitForSeconds (4);
		if (!Ritual_done) {
			End_game ();
		}
		else {
			Ritual_done = false;
			StartCoroutine (start_disaster ());
		}
	}
	void End_game(){
		Debug.Log ("Game ended");
	}
}
