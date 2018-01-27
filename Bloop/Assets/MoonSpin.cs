using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSpin : MonoBehaviour {

    public GameObject earth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(earth.transform.position, Vector3.up, 0.02f);
	}
}
