using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Slide : MonoBehaviour
{
    public GameObject[] cylinders;
    private int lastCylinder = 0;
    public float timeToRespawn = 1.5f;
    private float currentTime = 0;
    private Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = cylinders[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timeToRespawn)
        {
            currentTime = 0;
            cylinders[lastCylinder].transform.position = spawnPos;
            lastCylinder++;
            if (lastCylinder >= cylinders.Length) lastCylinder = 0;
        }
    }
}
