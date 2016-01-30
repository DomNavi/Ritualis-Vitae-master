using UnityEngine;
using System.Collections;

public class Disasters : MonoBehaviour {
	public string[] Disasters_list = {"storm","mosquitos","flood","heat"};
	public string Current_disaster;
	public bool Ritual_done = false;

    public GameObject StormClouds;
    public GameObject Rain;
    public GameObject Daylight;
    // Use this for initialization

    private bool storm = false;
    private bool mosquitos = false;
    private bool flood = false;
    private bool heat = false;

    private float lightIntensity;

    void Start () {
		
		StartCoroutine (wait_for_disaster());

	}
	
	// Update is called once per frame
	void Update () {
	    if(storm)
        {
            Color Temp = StormClouds.GetComponent<ParticleSystem>().startColor;
            Temp.r = Mathf.Lerp(Temp.r, 0.0f, 0.1f);
            Temp.g = Mathf.Lerp(Temp.g, 0.0f, 0.1f);
            Temp.b = Mathf.Lerp(Temp.b, 0.0f, 0.1f);
            if (Temp.r <= 0.2f)
            {
                Rain.GetComponent<ParticleSystem>().enableEmission = true;
                lightIntensity = Mathf.Lerp(lightIntensity, 0.1f, 0.06f);                
            }                       
            StormClouds.GetComponent<ParticleSystem>().startColor = Temp;
        }
        else
        {
            lightIntensity = Mathf.Lerp(lightIntensity, 0.6f, 0.06f);
        }
        Daylight.GetComponent<Light>().intensity = lightIntensity;
    }

	IEnumerator wait_for_disaster(){
		yield return new WaitForSeconds (4);
		StartCoroutine (start_disaster ());
	}
	IEnumerator start_disaster(){
        StormEnd();
        yield return new WaitForSeconds(1.5f);
		//Current_disaster =Disasters_list[Random.Range(0,Disasters_list.Length)];
		Current_disaster =Disasters_list[Random.Range(0,2)];
		switch (Current_disaster) {
			case "storm":
				Debug.Log ("Brace yourself, storm is coming!");
                StormStart();
				GetComponent<Rituals>().StormIsComing ();
				break;
			case "mosquitos":
				Debug.Log ("Mosquitos are heading your way!");
				GetComponent<Rituals>().MosquitosAreComing ();
				break;
			case "flood":
				Debug.Log ("Water is rising!");
				GetComponent<Rituals>().FloodIsComing ();
				break;
			case "heat":
				Debug.Log ("Its getting hot!");
				GetComponent<Rituals>().HeatIsComing ();
				break;
		}
		yield return new WaitForSeconds (6);
		if (!Ritual_done) {
			End_game ();
		}
	}

    void StormStart()
    {
        StormClouds.GetComponent<ParticleSystem>().enableEmission = true;
        lightIntensity = Daylight.GetComponent<Light>().intensity;      
        storm = true;
    }

    public void StormEnd()
    {
        StormClouds.GetComponent<ParticleSystem>().enableEmission = false;
        StormClouds.GetComponent<ParticleSystem>().startColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Rain.GetComponent<ParticleSystem>().enableEmission = false;
        storm = false;
    }


	void End_game(){
		Debug.Log ("Game ended");
	}
}
