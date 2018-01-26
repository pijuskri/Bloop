using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Vector2 direction = new Vector2(0,0);
    public GameObject planet;
    float speed=0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(planet.transform.position, direction, speed);
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.LookAt(planet.transform);
    }
}
