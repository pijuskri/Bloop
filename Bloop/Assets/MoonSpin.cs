using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSpin : MonoBehaviour {

    public GameObject earth;
    public float speed = 0.02f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(earth.transform.position, Vector3.up, speed);
	}
}
