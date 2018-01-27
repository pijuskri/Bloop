﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {


    public bool sender;
    public bool hasPacket = false;
    float time=0;
    public GameObject gameLogic;
	// Use this for initialization
	void Start () {
        time = 5;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (hasPacket == true && !sender) { gameLogic.GetComponent<GameLogic>().packetsSent++; hasPacket = false; }
	}
    public void SendPacket()
    {
        if (time > 5)
        {
            GameObject[] other = gameLogic.GetComponent<GameLogic>().sattelites;
            foreach (var sat in other)
            {
                RaycastHit hit;
                int index = LayerMask.NameToLayer("Sat");
                int mask = (1 << 8);

                if (!Physics.Linecast(transform.position, sat.transform.position, out hit, mask))
                {
                    Debug.DrawLine(transform.position, sat.transform.position, Color.red, 1);
                    sat.GetComponent<Transmission>().HasPacket = true;
                }
                else print(hit.transform.name);
            }
            time = 0;
        }
    }
}
