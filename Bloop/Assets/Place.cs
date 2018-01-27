using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour {

    public GameObject sattelite;
    public GameObject LinePrefab;
    GameObject Line;
    public GameObject planet;
    Vector3 LineStart = new Vector3();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            /*var mousePos = Input.mousePosition;
            mousePos.z = 5.0f;       // we want 2m away from the camera position
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(sattelite, objectPos, Quaternion.identity);
            */

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 temp = Input.mousePosition;
                
                temp = hitInfo.point;
                LineStart = hitInfo.point;
                // temp.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                //Instantiate(sattelite, temp, new Quaternion());

                Line = Instantiate(LinePrefab, new Vector3(0, 0, 0), new Quaternion());
                Line.GetComponent<LineRenderer>().SetPosition(0, LineStart);
            }
        }
        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 temp = Input.mousePosition;
                temp = hitInfo.point;
                // temp.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                Line.GetComponent<LineRenderer>().SetPosition(1, temp);
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject temp = Instantiate(sattelite, LineStart, new Quaternion());
            Vector2 direction = new Vector2();
            
            LineStart = Camera.main.WorldToScreenPoint(LineStart);
            Vector3 LineEnd = Camera.main.WorldToScreenPoint(Line.GetComponent<LineRenderer>().GetPosition(1));

            direction = new Vector2( LineEnd.x - LineStart.x, LineEnd.y - LineStart.y);
            if (direction.x > direction.y) direction = direction / direction.x;
            else if (direction.x < direction.y) direction = direction / direction.y;
            direction.x *= -1;

            //print(LineStart + " " + LineEnd);
            direction = new Vector2(direction.y, direction.x);
            temp.GetComponent<Orbit>().direction = direction;
            print(direction);
            temp.GetComponent<Orbit>().planet = planet;
            Destroy(Line);
        }
    }
}
