using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float speedAir = 50.0f;
    public float turnSpeed;
    private float horizontalInput;
    private float forwardInput;
    public float speedLand = 20f;

    private Rigidbody rigidBody;
    public float rotateSpeed;
    public float jumpSpeed;

    public Camera mainCamera;
    public Camera CockpitCamera;
    public KeyCode switchKey;

    Vector3 hRotate;
    Vector3 vRotate;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Land Controls
        horizontalInput = Input.GetAxis("Horizontal1");
        forwardInput = Input.GetAxis("Vertical1");
        //Move Plane fordward
        transform.Translate(Vector3.forward * Time.deltaTime * speedLand * forwardInput);
        //Rotate Plane left and right
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            CockpitCamera.enabled = !CockpitCamera.enabled;
        }
        hRotate = new Vector3(0, 0, -Input.GetAxis("Horizontal2"));
        vRotate = new Vector3(-Input.GetAxis("Vertical2"), 0, 0);
        // if (Input.GetKey("w"))
        // {
        //     rigidBody.MovePosition(rigidBody.position + transform.forward * Time.deltaTime * speedAir);
        // }
        if (Input.GetKey("space"))
        {
            rigidBody.MovePosition(rigidBody.position + transform.forward * Time.deltaTime * speedAir);
        }
        speedAir -= transform.forward.y * Time.deltaTime * 10.0f;
        Quaternion deltaHRotation = Quaternion.Euler(hRotate * Time.fixedDeltaTime * rotateSpeed);
        rigidBody.MoveRotation(rigidBody.rotation * deltaHRotation);
        Quaternion deltaVRotation = Quaternion.Euler(vRotate * Time.fixedDeltaTime * rotateSpeed);
        rigidBody.MoveRotation(rigidBody.rotation * deltaVRotation);

    }

}


