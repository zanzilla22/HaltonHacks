using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] team1spawns;
    public GameObject[] team2spawns;

    public Material team1Material;
    public Material team2Material;

    [HideInInspector]
    public int no1s = 0;
    [HideInInspector]
    public int no2s = 0;

    public int teamNumber = 1;
    void Start()
    {
        team1spawns = GameObject.FindGameObjectsWithTag("Spawn1");
        team2spawns = GameObject.FindGameObjectsWithTag("Spawn2");
        //StartCoroutine("Spawn");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<spawner>().teamNumber == 1)
                no1s++;
            if (players[i].GetComponent<spawner>().teamNumber == 2)
                no2s++;
        }
        if (no1s > no2s)
            teamNumber = 2;
        if (no1s < no2s)
            teamNumber = 1;
        if (no2s == no1s)
            teamNumber = Mathf.RoundToInt(Random.Range(1, 2));
        Spawn(teamNumber);
    }

    public void Spawn(int no)
    {
        //yield return new WaitForSeconds(0.1f);
        //Debug.Log("spawnPos: " + team1spawns[Random.Range(0, team1spawns.Length)].transform.position);
        if (no == 1)
        {
            Transform spawnPos = team1spawns[Random.Range(0, team1spawns.Length)].transform;
            this.transform.position = spawnPos.position;
            this.transform.rotation = spawnPos.rotation;
            if (this.GetComponent<Renderer>().material.name == "Default-Material (Instance)")
                this.GetComponent<Renderer>().material = team1Material;
        }
        //Debug.Log("spawnPosAcc: " + this.transform.position);
        if (no == 2)
        {
            Transform spawnPos = team2spawns[Random.Range(0, team2spawns.Length)].transform;
            this.transform.position = spawnPos.position;
            this.transform.rotation = spawnPos.rotation;
            if (this.GetComponent<Renderer>().material.name == "Default-Material (Instance)")
                this.GetComponent<Renderer>().material = team2Material;
        }
    }
}
