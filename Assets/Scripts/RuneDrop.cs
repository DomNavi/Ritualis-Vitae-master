using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RuneDrop : MonoBehaviour {


    Vector3 pos;
    public float yVelocity = 80.0f;

    void Start()
    {
        pos = GetComponent<RectTransform>().position;
        Debug.Log(pos.y);
        Drop();
    }

    void Update()
    {
        pos.y = Mathf.SmoothDamp(pos.y, 34.35f, ref yVelocity, 0.2f);
        GetComponent<RectTransform>().position = pos;
    }

    public void Drop()
    {
        pos.y = 70.0f;
        gameObject.SetActive(true);
    }
}
