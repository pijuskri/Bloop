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
        /*GameObject[] other = GameObject.FindGameObjectsWithTag("Sattelite");
        foreach (var sat in other)
        {
            if (sat != gameObject)
            {
                GameObject temp = new GameObject();
                temp.tag = "laser";
                temp.transform.SetParent(gameObject.transform);
                temp.AddComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
                temp.GetComponent<LineRenderer>().SetPosition(1, sat.transform.position);
            }
        }
        */
	}
}
