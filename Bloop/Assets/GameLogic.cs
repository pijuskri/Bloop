using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    [HideInInspector] public GameObject[] sattelites = new GameObject[0];
    [HideInInspector] public int packetsRequired = 5;
    [HideInInspector] public int packetsSent = 0;
    [HideInInspector] public int sattelitesLeft = 5;
    public GameObject button;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (packetsSent >= packetsRequired) Destroy(button);
	}
    public void CheckSattelites()
    {
        
        sattelites = GameObject.FindGameObjectsWithTag("Sattelite");
        print("checked");
        print(sattelites.Length);
    } 
}
