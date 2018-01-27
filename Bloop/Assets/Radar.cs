using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {


    public bool sender;
    public bool hasPacket = false;
    float time=0;
    GameObject gameLogic;
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
            GameObject[] other = GameObject.FindGameObjectsWithTag("Sattelite");
            foreach (var sat in other) print(sat.transform.name);
            foreach (var sat in other)
            {
                RaycastHit hit;
                int mask = (1 << 8);
                if (!Physics.Linecast(transform.position, sat.transform.position, out hit, mask))
                {
                    print(other.Length);
                    if (sat != null)
                    {
                        print(sat.transform.name);
                        print(sat.GetComponent<Orbit>().direction);
                        print(sat.GetComponent<Transmission>().HasPacket);
                        Debug.DrawLine(transform.position, sat.transform.position, Color.red, 2);
                        sat.GetComponent<Transmission>().HasPacket = true;
                    }
                }
            }
            time = 0;
        }
    }
}
