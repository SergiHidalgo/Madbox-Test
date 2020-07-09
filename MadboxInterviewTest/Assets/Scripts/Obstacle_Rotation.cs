using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Rotation : MonoBehaviour
{
    public float maxRotationSpeed = 30;
    public float minRotationSpeed = 10;
    private float rotationSpeed;
    public Vector3 direction = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Rotate(direction, Time.deltaTime * rotationSpeed);
    }
}
