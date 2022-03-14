using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // référence au vaisseau
    // public GameObject playerObject;
    // référence à un mousePositionObject
    public GameObject mousePositionObject;

    // vitesse actuelle (privé)
    private float speed = 0f;
    // vitesse du player
    [SerializeField] private float maxSpeed = 10f;
    // valeurs de vitesse d'accélération, de décélération et de rotation
    [SerializeField] private float acceleration = 3f;
    [SerializeField] private float deceleration = 8f;
    [SerializeField] private float rotationSpeed = 300f;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void FixedUpdate() 
    {
        // ---- rotation vers mousePositionObject ----

        // calcule la différence entre la position du "mousePositionObject" et du player
        Quaternion toRotation = Quaternion.LookRotation(mousePositionObject.transform.position - transform.position);

        // tourne vers "toRotation"
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        //ligne qui fonctionne pour se tourner d'un coup vers l'objet
        //transform.LookAt(mousePositionObject.transform);


        // ---- déplacement vers mousePositionObject ----

        // bonne ligne pour le déplacement
        //transform.position = Vector3.MoveTowards(transform.position, mousePositionObject.transform.position, (speed / 10) );
        
        // create a forward vector
        Vector3 forward = transform.position + transform.forward;
        Vector3 betterForward = new Vector3(forward.x, 2f, forward.z);
        // Debug.Log( "forward =" + forward );
        // Debug.Log( "betterForward =" + betterForward );


        // ligne pour le déplacement modifié
        transform.position = Vector3.MoveTowards(transform.position, betterForward, (speed / 10) );
        

        // ---- accélération et décélération ---- 

        if (Input.GetKey("space"))
        {
            // tant que espace est préssé, "speed" augmente lentement vers "maxSpeed" à la vitesse de 3 * Time.deltaTime
            speed = Mathf.SmoothStep(speed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (Input.GetKey("space") == false)
        {
            // tant que espace n'est pas préssé, "speed" devient lentement 0 à la vitesse de 8 * Time.deltaTime
            speed = Mathf.SmoothStep(speed, 0f, deceleration * Time.deltaTime);
        } 

    }
}
