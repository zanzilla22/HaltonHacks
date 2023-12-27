using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tire : MonoBehaviour
{
    private GameObject audioListener;
    public AudioClip bounce;
    void Start()
    {
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("sound");
        audioListener = sounds[0];
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<fpsController>().Bounce();
            AudioSource.PlayClipAtPoint(bounce, audioListener.transform.position);
        }
    }
}
