using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {


    public bool sender;
    public bool hasPacket = false;
    public bool received = false;
    float time=0;
    public GameObject gameLogic;
	// Use this for initialization
	void Start () {
        time = 5;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (hasPacket && !sender && !received) { gameLogic.GetComponent<GameLogic>().packetsSent++; received = true; }
	}
    public void SendPacket()
    {
        if (time > 5)
        {
            GameObject[] other = gameLogic.GetComponent<GameLogic>().sattelites;
            foreach (var sat in other)
            {
                if (Vector3.Distance(sat.transform.position, transform.position) < 20)
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
            }
            time = 0;
        }
    }
}
