using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {

    // Use this for initialization
    public bool HasPacket = false;
    float time;

    void Start () {
        time = 3;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (HasPacket && time>3) SendPacket();
	}
    void SendPacket()
    {
        print("lol");
        GameObject[] other = GameObject.FindGameObjectsWithTag("Sattelite");
        foreach (var sat in other)
        {
            if (sat != gameObject)
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
                
                    Debug.DrawLine(transform.position, sat.transform.position, Color.red, 1);
                    sat.GetComponent<Transmission>().HasPacket = true;
                }
                /*GameObject temp = new GameObject();
                temp.tag = "laser";
                temp.transform.SetParent(gameObject.transform);
                temp.AddComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
                temp.GetComponent<LineRenderer>().SetPosition(1, sat.transform.position);*/
            }
        }
        GameObject[] ob = GameObject.FindGameObjectsWithTag("observatory");
        foreach (var observ in ob)
        {
            if (observ != gameObject)
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

                    Debug.DrawLine(transform.position, observ.transform.position, Color.red, 1);
                    observ.GetComponent<Radar>().hasPacket = true;
                }
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
