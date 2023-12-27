using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    GameObject[] ps;
    public AudioClip FootstepSound;
    private GameObject audioListener;
    private float curFootstepTime;
    public float timeBetweenFootsteps;
    void Start()
    {
        curFootstepTime = timeBetweenFootsteps;
        ps = GameObject.FindGameObjectsWithTag("Player");

        GameObject[] sounds = GameObject.FindGameObjectsWithTag("sound");
        audioListener = sounds[0];
    }
    void Update()
    {
        if (curFootstepTime <= 0)
        {
            PlayFootStep();
            curFootstepTime = timeBetweenFootsteps;
        }
    }
    void PlayFootStep()
    {
        float shortestDist = 0;
        for (int i = 0; i < ps.Length; i++)
        {
            if (ps[i] != this.gameObject)
            {
                float curDist = Vector3.Distance(this.transform.position, ps[i].transform.position);
                if (shortestDist == 0 || shortestDist > curDist)
                    shortestDist = curDist;
                //Debug.Log(shortestDist);
            }
        }
        AudioSource.PlayClipAtPoint(FootstepSound, audioListener.transform.position + new Vector3(0, shortestDist, 0));
    }
    public void SubFootstepTime(float time_)
    {
        curFootstepTime -= Mathf.Abs(time_);
        //Debug.Log(curFootstepTime);
    }
}
