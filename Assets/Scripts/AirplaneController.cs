using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
     public float speedAir = 50.0f;

    // void Update()
    // {
    //     transform.position += transform.forward*Time.deltaTime*speedAir;
    //     speedAir -= transform.forward.y * Time.deltaTime *10.0f;
    //     transform.Rotate(-Input.GetAxis("Vertical2"),0.0f,-Input.GetAxis("Horizontal2"));
    // }

    public float turnSpeed;
    private float horizontalInput;
    private float forwardInput;
    public float speedLand = 20f;

    private Rigidbody rigidBody;
    public float forwardThrustForce = 40.0f;

    public Camera mainCamera;
    public Camera CockpitCamera;
    public KeyCode switchKey;

    void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}

    void Update(){
        //Land Controls
        horizontalInput = Input.GetAxis("Horizontal1");
        forwardInput = Input.GetAxis("Vertical1");
        //Move Plane fordward
        transform.Translate(Vector3.forward * Time.deltaTime * speedLand * forwardInput);
        //Rotate Plane left and right
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if(Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            CockpitCamera.enabled = !CockpitCamera.enabled;
        }

        if (Input.GetButton("Jump"))
        {
            transform.position += transform.forward*Time.deltaTime*speedAir;
            speedAir -= transform.forward.y * Time.deltaTime *10.0f;
            transform.Rotate(-Input.GetAxis("Vertical2"),0.0f,-Input.GetAxis("Horizontal2"));
        }
    }
    
}
    

