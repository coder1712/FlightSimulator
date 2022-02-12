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

    Vector3 m_EulerAngleVelocity;
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
        m_EulerAngleVelocity = new Vector3(0, 0, -Input.GetAxis("Horizontal2"));

        if (Input.GetKey("w"))
        {
            rigidBody.MovePosition(rigidBody.position + transform.forward * Time.deltaTime * speedAir);
        }
        if (Input.GetKey("w") && Input.GetKey("space"))
        {
            rigidBody.MovePosition(rigidBody.position + transform.up * jumpSpeed + transform.forward * Time.deltaTime * speedAir);
        }
        speedAir -= transform.forward.y * Time.deltaTime * 10.0f;
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime * rotateSpeed);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);

    }

}


