using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour {

    public GameObject sattelite;
    public GameObject LinePrefab;
    GameObject Line;
    public GameObject planet;
    Vector3 LineStart = new Vector3();
    bool IsAbleToPlace = false;
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
                Line.GetComponent<LineRenderer>().endWidth = 0.02f;
                Line.GetComponent<LineRenderer>().startWidth = 0.04f;
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



            Vector3 LineStartTemp = Camera.main.WorldToScreenPoint(LineStart);
            Vector3 LineEnd = Camera.main.WorldToScreenPoint(Line.GetComponent<LineRenderer>().GetPosition(1));

            Vector2 direction = new Vector2();
            direction = new Vector2(LineEnd.x - LineStartTemp.x, LineEnd.y - LineStartTemp.y);
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) direction = direction / Mathf.Abs(direction.x);
            else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) direction = direction / Mathf.Abs(direction.y);

            GameObject m = new GameObject();
            Transform tempTransform = m.transform;
            tempTransform.position = LineStart;
            tempTransform.LookAt(planet.transform);

            float rotation=0;
            if (tempTransform.rotation.eulerAngles.x < 180) rotation = tempTransform.rotation.eulerAngles.x;
            else rotation = 360 - tempTransform.rotation.eulerAngles.x;

            //if(Mathf.Abs( direction.y) - Mathf.Abs(direction.x)<-0.4 && rotation>10) IsAbleToPlace = false;
            if(Vector3.Distance(LineStart, Line.GetComponent<LineRenderer>().GetPosition(1))>1f) IsAbleToPlace = false;
            else if(Vector3.Distance(LineStart, Line.GetComponent<LineRenderer>().GetPosition(1)) < 0.05f) IsAbleToPlace = false;
            else IsAbleToPlace = true;
            //if (Mathf.Abs( direction.y ) - rotation / 90 < 0.1) Line.GetComponent<LineRenderer>().material.color = Color.green;
            //else Line.GetComponent<LineRenderer>().material.color = Color.red;
            //print(direction.y + " " + direction.x);

            if(IsAbleToPlace) Line.GetComponent<LineRenderer>().material.color = Color.green;
            else Line.GetComponent<LineRenderer>().material.color = Color.red;

            Destroy(m);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject temp;
            
            Vector3 direction = new Vector3();



            /*Vector3 LineStartTemp = Camera.main.WorldToScreenPoint(LineStart);
            Vector3 LineEnd = Camera.main.WorldToScreenPoint(Line.GetComponent<LineRenderer>().GetPosition(1));
            direction = new Vector3( LineEnd.x - LineStartTemp.x, LineEnd.y - LineStartTemp.y, 0);
            if (Mathf.Abs( direction.x )> Mathf.Abs(direction.y)) direction = direction / Mathf.Abs( direction.x);
            else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) direction = direction / Mathf.Abs(direction.y);*/
            Vector3 LineEnd = Line.GetComponent<LineRenderer>().GetPosition(1);
            direction = new Vector3(LineEnd.x - LineStart.x, LineEnd.y - LineStart.y, LineEnd.z - LineStart.z);
            direction = direction.normalized;
            if (Mathf.Abs(direction.x) < 0.15f) direction.x = 0;
            if (Mathf.Abs(direction.y) < 0.15f) direction.y = 0;
            if (Mathf.Abs(direction.z) < 0.15f) direction.z = 0;

            print(direction);

            //direction = new Vector3(direction.y, direction.x, direction.z);
            if (IsAbleToPlace)
            {
                GameObject empty = new GameObject();
                empty.transform.position = new Vector3( planet.transform.position.x, planet.transform.position.y, planet.transform.position.z);
                temp = Instantiate(sattelite, LineStart, Quaternion.Euler(0,0,0), empty.transform);
                temp.GetComponent<Orbit>().direction = direction;
                temp.GetComponent<Orbit>().planet = planet;
                temp.GetComponent<Orbit>().parent = empty;
            }
            Destroy(Line);
        }
    }
}
