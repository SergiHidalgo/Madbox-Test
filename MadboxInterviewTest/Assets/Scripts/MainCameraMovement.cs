using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
    public Transform[] cameraPositions;
    public Transform PlayerTransform;
    private int currentPositionNumber = 0;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerTransform); //Camera always is pointing at the player
        transform.position = Vector3.Lerp(transform.position, cameraPositions[currentPositionNumber].position, 0.03f);
    }
    public void ChangeTargetPosition(int newPos)
    {
        currentPositionNumber = newPos;
    }
}
