using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public MainCameraMovement camMovementScript;
    // Movement variables
    public float maxSpeed;
    public float acceleration;
    public float decelerate;
    public float speed;
    // Restart variables
    private Vector3 respawnPosition;
    private bool restart = false;
    public float timeToRestartAftherDies = 2;
    private float currentRestartTime = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // If mouse is down we increment the acceleration if is less than the maimum
        {           
            if (speed < maxSpeed) speed += acceleration * Time.deltaTime; 
            else speed = maxSpeed;
        }
        else // If mouse is not down we reduce de speed up to zero
        {
            if (speed > 0) speed -= decelerate * Time.deltaTime;
            else speed = 0;
        }
        
        if (restart) // If player dies we wait X time until we restart
        {
            currentRestartTime += Time.deltaTime;
            if (currentRestartTime >= timeToRestartAftherDies)
            {
                restart = false;
                currentRestartTime = 0;
                Die();
            }
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            MoveFront();
        }
    }
    private void MoveFront()
    {
        playerRB.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Zone1":
                respawnPosition = transform.position;
                camMovementScript.ChangeTargetPosition(1);
                break;
            case "Zone2":
                respawnPosition = transform.position;
                camMovementScript.ChangeTargetPosition(2);
                break;
            case "Zone4":
                respawnPosition = transform.position;
                camMovementScript.ChangeTargetPosition(3);
                break;
            case "Finish": // When player finish the level we reload the Scene to start again
                SceneManager.LoadScene(0);
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            playerRB.constraints = RigidbodyConstraints.None;            
            restart = true;
        }
    }
    private void Die() // We restart the rotation de constrains and the position
    {
        transform.position = respawnPosition;
        transform.rotation = Quaternion.identity;
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
