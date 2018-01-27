using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    public int packetsRequired = 1;
    public int packetsSent = 0;
    public int sattelitesLeft = 10;
    public GameObject button;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (packetsSent >= packetsRequired) Destroy( button);
	}
}
