using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {

    // Use this for initialization
    public GameObject[] satList;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] other = GameObject.FindGameObjectsWithTag("Sattelite");
        foreach (var sat in other)
        {
            if (sat != gameObject)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, sat.transform.position, out hit, 8))
                {
                    print(hit.transform.gameObject.name);
                    if (hit.transform.tag == "Sattelite")
                    {
                        Debug.DrawLine(transform.position, sat.transform.position);
                    }
                }
                /*GameObject temp = new GameObject();
                temp.tag = "laser";
                temp.transform.SetParent(gameObject.transform);
                temp.AddComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
                temp.GetComponent<LineRenderer>().SetPosition(1, sat.transform.position);*/
            }
        }
        
	}
}
