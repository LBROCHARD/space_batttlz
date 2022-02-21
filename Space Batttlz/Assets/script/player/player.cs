using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController controller;

    public GameObject MousePositionObject;

    public float speed = 6f;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, MousePositionObject.transform.position, 0.1f);
        transform.LookAt(MousePositionObject.transform);

        // float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");
        // Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // // Vector3 direction = mouseObjectPosition.normalized;

        // if( direction.magnitude >= 0.1f){

            // float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // transform.rotation = Quaternion.Euler(0f, angle, 0f); 

            // controller.Move(direction * speed * Time.deltaTime);
        // }

    }
}
