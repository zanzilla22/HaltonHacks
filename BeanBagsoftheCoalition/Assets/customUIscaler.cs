using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customUIscaler : MonoBehaviour
{

    public Camera cam;
    private Vector3 orScale;
    private Vector3 orPos;

    public bool changeScale = true;
    void Awake()
    {
        orScale = this.GetComponent<RectTransform>().localScale;
        orPos = this.GetComponent<RectTransform>().anchoredPosition;
    }
    void Update()
    {
        //2 players
        if (cam.rect == new Rect(new Rect(0, 0, 0.5f, 1)) || cam.rect == new Rect(0.5f, 0, 0.5f, 1))
        {
            if(changeScale)
                this.GetComponent<RectTransform>().localScale = new Vector3(orScale.x / 2, orScale.y, orScale.z);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(orPos.x/2, orPos.y, orPos.z);
        }
        //3+players
        if (cam.rect == new Rect(0, 0.5f, 0.5f, 0.5f) || cam.rect == new Rect(0.5f, 0.5f, 0.5f, 0.5f) || cam.rect == new Rect(0, 0, 0.5f, 0.5f) || cam.rect == new Rect(0.5f, 0, 0.5f, 0.5f))
        {
            this.GetComponent<RectTransform>().localScale = new Vector3(orScale.x / 2, orScale.y / 2, orScale.z);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(orPos.x / 2, orPos.y/2.5f, orPos.z);
        }
    }
}
