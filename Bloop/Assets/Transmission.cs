using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {

    // Use this for initialization
    public bool HasPacket = false;
    public GameObject gameLogic;
    float time;

    void Start () {
        time = 3;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (HasPacket && time>3) SendPacket();
        if (time < 3) HasPacket = false;
	}
    void SendPacket()
    {
        print("lol");
        GameObject[] other = gameLogic.GetComponent<GameLogic>().sattelites;
        foreach (var sat in other)
        {
            if (sat != gameObject)
            {
                if (Vector3.Distance(sat.transform.position, transform.position) < 20)
                {
                    RaycastHit hit;
                    int index = LayerMask.NameToLayer("Sat");
                    //int mask = (1 << index);
                    int mask = (1 << 8);
                    //print(mask);
                    //print(LayerMask.LayerToName(mask));


                    if (!Physics.Linecast(transform.position, sat.transform.position, out hit, mask))
                    {
                        //print(hit.transform.gameObject.name);

                        //Debug.DrawLine(transform.position, sat.transform.position, Color.red, 1);
                        if (gameLogic.GetComponent<LineRenderer>().positionCount == 0)
                        {
                            gameLogic.GetComponent<LineRenderer>().positionCount = 1;
                            gameLogic.GetComponent<LineRenderer>().SetPosition(0, transform.position);
                        }
                        gameLogic.GetComponent<LineRenderer>().positionCount++;
                        gameLogic.GetComponent<LineRenderer>().SetPosition(gameLogic.GetComponent<LineRenderer>().positionCount-1, sat.transform.position);
                        sat.GetComponent<Transmission>().HasPacket = true;
                    }
                    else print(hit.transform.name);
                    /*GameObject temp = new GameObject();
                    temp.tag = "laser";
                    temp.transform.SetParent(gameObject.transform);
                    temp.AddComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
                    temp.GetComponent<LineRenderer>().SetPosition(1, sat.transform.position);*/
                }
            }
        }
        GameObject[] ob = GameObject.FindGameObjectsWithTag("observatory");
        foreach (var observ in ob)
        {
            if (Vector3.Distance(observ.transform.position, transform.position) < 20)
            {
                RaycastHit hit;
                int index = LayerMask.NameToLayer("Sat");
                //int mask = (1 << index);
                int mask = (1 << 8);
                //print(mask);
                //print(LayerMask.LayerToName(mask));


                if (!Physics.Linecast(transform.position, observ.transform.position, out hit, mask))
                {
                    //print(hit.transform.gameObject.name);

                    if (gameLogic.GetComponent<LineRenderer>().positionCount == 0)
                    {
                        gameLogic.GetComponent<LineRenderer>().positionCount = 1;
                        gameLogic.GetComponent<LineRenderer>().SetPosition(0, transform.position);
                    }
                    gameLogic.GetComponent<LineRenderer>().positionCount++;
                    gameLogic.GetComponent<LineRenderer>().SetPosition(gameLogic.GetComponent<LineRenderer>().positionCount - 1, observ.transform.position);
                    observ.GetComponent<Radar>().hasPacket = true;
                }
                else print("lol+" + hit.transform.name);
                /*GameObject temp = new GameObject();
                temp.tag = "laser";
                temp.transform.SetParent(gameObject.transform);
                temp.AddComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
                temp.GetComponent<LineRenderer>().SetPosition(1, sat.transform.position);*/
            }
        }
        HasPacket = false;
        time = 0;
    }
}
