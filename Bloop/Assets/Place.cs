using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour {

    public GameObject sattelite;
    public GameObject LinePrefab;
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
               // temp.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                Instantiate(sattelite, temp, new Quaternion());
            }
        }
    }
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            LineStart = hitInfo.point;
            // temp.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }
}
