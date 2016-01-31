using UnityEngine;
using System.Collections;

public class Disasters : MonoBehaviour {
	public string[] Disasters_list = {"storm","mosquitos","earthquake","heat"};
	public string Current_disaster;
	public int Ritual_done = 0;

    public GameObject StormClouds;
    public GameObject Rain;
    public GameObject Daylight;

    public GameObject MainCamera;
    private bool shake;

    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject Sun;
    private bool hot = false;

    public GameObject MosquitosCloud;
    // Use this for initialization

    private bool storm = false;
    private bool mosquitos = false;
    private bool earthquake = false;
    private bool heat = false;
    private bool DisasterInProgress = false;

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
        if(mosquitos)
        {
            Vector3 tempPos = MosquitosCloud.GetComponent<Transform>().localPosition;
            tempPos.x = Mathf.Lerp(tempPos.x, 7.0f, 1.0f * Time.deltaTime);
            MosquitosCloud.GetComponent<Transform>().localPosition = tempPos;
        }

        if(shake)
        {
            MainCamera.GetComponent<Transform>().rotation = Quaternion.Slerp(MainCamera.GetComponent<Transform>().rotation, Quaternion.Euler(356.77f, Random.Range(-4f, 4f), Random.Range(-3.5f, 1f)), Time.deltaTime * 2.8f);
        }
        else
        {
            MainCamera.GetComponent<Transform>().rotation = Quaternion.Slerp(MainCamera.GetComponent<Transform>().rotation, Quaternion.Euler(356.77f, 0f, -1.72f), Time.deltaTime * 2.8f);
        }

        if(hot)
        {
            Color tmp = Sun.GetComponent<ParticleSystem>().startColor;
            tmp.a = Mathf.Lerp(tmp.a, 1.0f, 2.0f * Time.deltaTime);
            Sun.GetComponent<ParticleSystem>().startColor = tmp;
        }

        else
        {
            Color tmp = Sun.GetComponent<ParticleSystem>().startColor;
            tmp.a = Mathf.Lerp(tmp.a, 7f/255f, 2.0f * Time.deltaTime);
            Sun.GetComponent<ParticleSystem>().startColor = tmp;
        }
    }

	IEnumerator wait_for_disaster(){
		yield return new WaitForSeconds (4);
		StartCoroutine (start_disaster ());
	}
	IEnumerator start_disaster(){
        GetComponent<TextFade>().FadeTo(true);
        DisasterInProgress = true;
        StormEnd();
        MosquitosEnd();
        EarthquakeEnd();
        HeatEnd();
        yield return new WaitForSeconds(1.5f);
        Current_disaster = Disasters_list[Random.Range(0,Disasters_list.Length)];
        //Current_disaster = Disasters_list[Random.Range(0,2)];
		switch (Current_disaster) {
			case "storm":
				//Debug.Log ("Brace yourself, storm is coming!");
                StormStart();
				GetComponent<Rituals>().StormIsComing ();
				break;
			case "mosquitos":
				//Debug.Log ("Mosquitos are heading your way!");
                MosquitosStart();
				GetComponent<Rituals>().MosquitosAreComing ();
				break;
			case "earthquake":
				//Debug.Log ("Water is rising!");
                EarthquakeStart();
                GetComponent<Rituals>().EarthquakeIsComing ();
				break;
			case "heat":
				//Debug.Log ("Its getting hot!");
                HeatStart();
                GetComponent<Rituals>().HeatIsComing ();
				break;
		}
		yield return new WaitForSeconds (6);
		if (Ritual_done == 0) {
			End_game ();
            GetComponent<Rituals>().TimeText.SetActive(false);
		}
        Ritual_done--;
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

    void MosquitosStart()
    {
        MosquitosCloud.GetComponent<ParticleSystem>().enableEmission = true;
        mosquitos = true;
        Vector3 tempPos = MosquitosCloud.GetComponent<Transform>().localPosition;
        tempPos.x = -9.11f;
        MosquitosCloud.GetComponent<Transform>().localPosition = tempPos;
    }

    public void MosquitosEnd()
    {
        MosquitosCloud.GetComponent<ParticleSystem>().enableEmission = false;
        mosquitos = false;
    }

    void EarthquakeStart()
    {
        shake = true;
    }

    public void EarthquakeEnd()
    {
        shake = false;
    }

    void HeatStart()
    {
        hot = true;
        StartCoroutine(LightUp());
        Sun.GetComponent<ParticleSystem>().emissionRate = 50;
        Sun.GetComponent<ParticleSystem>().startSpeed = 1.18f;

    }

    public void HeatEnd()
    {
        hot = false;
        Fire1.SetActive(false);
        Fire2.SetActive(false);
        Fire3.SetActive(false);
        Sun.GetComponent<ParticleSystem>().emissionRate = 25;
        Sun.GetComponent<ParticleSystem>().startSpeed = 0.18f;
    }

    IEnumerator LightUp()
    {
        yield return new  WaitForSeconds(1);
        Fire1.SetActive(true);
        Fire2.SetActive(true);
        Fire3.SetActive(true);
    }

    void End_game()
    {
		Debug.Log ("Game ended");
        Time.timeScale = 0.0f;
    }
}
