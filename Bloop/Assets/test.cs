using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject cube;
    Transform center;
    Vector3 axis = Vector3.up;
    Vector3 desiredPosition;
    float radius = 6.0f;
    float radiusSpeed = 10f;
    float rotationSpeed = 80.0f;

    void Start()
    {
        center = cube.transform;
        transform.position = (transform.position - center.position).normalized * radius + center.position;
    }

    void Update()
    {
        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
}
