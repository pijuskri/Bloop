using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Vector2 direction = new Vector2(0,0);
    public GameObject planet;
    float speed=0.01f;
    float initialDistance;
	// Use this for initialization
	void Start () {
        initialDistance = Vector3.Distance(planet.transform.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.RotateAround(planet.transform.position, new Vector3(direction.x, 0, 0), speed);
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.LookAt(planet.transform);
        transform.Translate(direction * speed);
        //print(transform.rotation.eulerAngles);
        if ((transform.rotation.eulerAngles.x > 89.7 && transform.rotation.eulerAngles.x < 90.3)||(transform.rotation.eulerAngles.x > 269.7 && transform.rotation.eulerAngles.x < 270.4))
        {
            transform.Translate(direction * speed * 3);
            direction *= -1;
        }
        if(Vector3.Distance(planet.transform.position, transform.position)> initialDistance) transform.Translate(Vector3.forward * 0.02f);

        if (direction.x == 0 && direction.y == 0) Destroy(gameObject);
    }

}
