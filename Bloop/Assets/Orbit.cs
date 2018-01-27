using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Vector3 direction = new Vector3(0,0,0);
    public GameObject planet;
    float speed=0.1f;
    float initialDistance;
	// Use this for initialization
	void Start () {
        initialDistance = Vector3.Distance(planet.transform.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        /*transform.LookAt(planet.transform);
        transform.Translate(direction * speed);
        if ((transform.rotation.eulerAngles.x > 89.7 && transform.rotation.eulerAngles.x < 90.3)||(transform.rotation.eulerAngles.x > 269.7 && transform.rotation.eulerAngles.x < 270.4))
        {
            transform.Translate(direction * speed * 10);
            direction *= -1;
        }
        if(Vector3.Distance(planet.transform.position, transform.position)> initialDistance) transform.Translate(Vector3.forward * 0.02f);

        if (direction.x == 0 && direction.y == 0) Destroy(gameObject);

        transform.eulerAngles = new Vector3(0,0,0);*/
        Quaternion q = Quaternion.FromToRotation(-transform.up, planet.transform.up);

        //print(q.eulerAngles);

        float multi=0;
        multi = q.eulerAngles.y / 360;
        //if(q.eulerAngles.y<=180) multi = (180 - q.eulerAngles.y) / 180;
        //else if (q.eulerAngles.y > 180) multi = (q.eulerAngles.y - 180) / 180;

        print(q.eulerAngles.y  +" "+ multi);

        //transform.RotateAround(planet.transform.position, direction, speed);
        transform.RotateAround(planet.transform.position, Vector3.down, direction.x * speed);
        transform.RotateAround(planet.transform.position, Vector3.right, direction.y * speed * (1-multi));
        transform.RotateAround(planet.transform.position, Vector3.back, direction.y * speed * multi);
    }

}
