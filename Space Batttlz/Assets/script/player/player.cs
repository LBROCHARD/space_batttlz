using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController controller;

    public GameObject mousePositionObject;

    private float speed = 0f;
    // private float targetedSpeed = 0f;
    public float maxSpeed = 10f;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if (Input.GetKeyDown("space"))
        // {
        //     //transform.position = Vector3.MoveTowards(transform.position, mousePositionObject.transform.position, (speed / 100) );
        //     targetedSpeed = maxSpeed;
        
        // } 
        // else if (Input.GetKey("space") == false)
        // {
        //     targetedSpeed = 0f;
        // }

    }

    void FixedUpdate() 
    {

        transform.LookAt(mousePositionObject.transform);
        
        // speed = Mathf.SmoothStep(speed, targetedSpeed, 5 * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, mousePositionObject.transform.position, (speed / 10) );
        

        if (Input.GetKey("space"))
        {
            speed = Mathf.SmoothStep(speed, maxSpeed, 3 * Time.deltaTime);
        }
        else if (Input.GetKey("space") == false)
        {
            speed = Mathf.SmoothStep(speed, 0f, 8 * Time.deltaTime);
        }

    }
}
