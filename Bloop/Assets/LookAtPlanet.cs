using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlanet : MonoBehaviour {

    float speed = 0.1f;
    public GameObject planet;
    float initialDistance;
    bool moonTransition = false;
    public bool isMoon = false;
    float time=0;
    float movementSpeed = 0.2f;
    public GameObject moon;
    public bool free = false;
    // Use this for initialization
    void Start() {
        initialDistance = Vector3.Distance(transform.position, planet.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (free)
            {
                free = false;
                Cursor.visible = true;
            }
            else { free = true; Cursor.visible = false; }
        }
        time += Time.deltaTime;
        if (!free)
        {
            if (time > 3 && moonTransition)
            {
                moonTransition = false;
                //transform.parent = moon.transform;
                moon.GetComponent<MoonSpin>().speed = 0;
            }
            // transform.LookAt(planet.transform);
            if (moonTransition)
            {
                Vector3 direction = moon.transform.position - transform.position;
                Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 2);
                //transform.position = Vector3.MoveTowards(transform.position, moon.transform.position, 0.04f);
            }
            else
            {
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");
                //transform.RotateAround(planet.transform.position, Vector3.up, x * speed);
                //transform.RotateAround(planet.transform.position, Vector3.right, y * speed);
                float convertAnglex = 0;
                if (transform.rotation.eulerAngles.x <= 180) convertAnglex = transform.rotation.eulerAngles.x;
                if (transform.rotation.eulerAngles.x > 180) convertAnglex = -(360 - transform.rotation.eulerAngles.x);
                //print(convertAnglex);
                if (y > 0 && convertAnglex > 70) y = 0;
                if (y < 0 && convertAnglex < -70) y = 0;

                transform.Translate(new Vector3(x * speed, y * speed, 0));
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.LookAt(planet.transform.position);
                if (Vector3.Distance(transform.position, planet.transform.position) > initialDistance) transform.Translate(Vector3.forward * 0.04f);
            }
        }
        else
        {
            FreeCam();
        }
       
    }
    public void MoveToMoon()
    {
        moonTransition = true;
        planet = moon;
        isMoon = true;
        time = 0;
        //transform.LookAt(planet.transform);
        initialDistance = 5;
    }
    public void FreeCam()
    {
        
        movementSpeed = Mathf.Max(movementSpeed += Input.GetAxis("Mouse ScrollWheel") / 5, 0.0f);
        transform.position += (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical") + transform.up * Input.GetAxis("Depth")) * movementSpeed;
        transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
    }
}

