using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlane : MonoBehaviour
{
    public GameObject objectToFollow;

    public Vector3 positionRelativeToObject = new Vector3(0, 50, -300);
    public float followBias = 0.05f;

    void FixedUpdate () {
        var idealCameraPosition = (objectToFollow.transform.rotation * positionRelativeToObject) + objectToFollow.transform.position;
        var cameraVelocity = (idealCameraPosition - transform.position) * followBias;
        transform.position += cameraVelocity;
        transform.LookAt(objectToFollow.transform.position);
    }
}
