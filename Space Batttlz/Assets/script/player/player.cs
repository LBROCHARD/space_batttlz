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

        Vector3 direction = mousePositionObject.transform.position - transform.position;
        //Debug.Log("direction =" + direction);
        Quaternion toRotation = Quaternion.LookRotation(transform.forward, direction);
        Debug.Log("toRotation =" + toRotation);
        //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1 * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1 * Time.deltaTime);

        //transform.LookAt(mousePositionObject.transform);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 100f, 0.0f), 1 * Time.deltaTime);

        // speed = Mathf.SmoothStep(speed, targetedSpeed, 5 * Time.deltaTime);
        //DAGOOD//transform.position = Vector3.MoveTowards(transform.position, mousePositionObject.transform.position, (speed / 10) );
        transform.position = Vector3.MoveTowards(transform.position, direction, (speed / 10) );
        

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
