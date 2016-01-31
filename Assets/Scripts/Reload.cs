using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {

	public void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1.0f;
    }
}
