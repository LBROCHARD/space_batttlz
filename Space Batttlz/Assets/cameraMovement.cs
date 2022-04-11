using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    // get what the camera should follow
    public Transform target;
    // speed of "lag" of the camera
    public float smoothSpeed = 0.125f;
    // offset of the camera compared to the target
    public Vector3 offset;

    void Start()
    {
    }

    void Update()
    {
    }

    // exactly like update but right after it, so player as done all it's movement when this function is called
    void FixedUpdate()
    {

        // "desiredPosition" is the target position + the offset of camera
        Vector3 desiredPosition = target.position + offset;
        // "smoothPosition" is a lerp to give to the camera a time ("smoothSpeed") before getting to the "desiredPosition"
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // actual position = "smoothPosition"
        transform.position = smoothPosition;

    }
}
