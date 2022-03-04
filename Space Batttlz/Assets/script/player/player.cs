using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // référence à un controller
    public CharacterController controller;
    // référence à un mousePositionObject
    public GameObject mousePositionObject;

    // vitesse actuelle (privé)
    private float speed = 0f;
    // vitesse du player
    public float maxSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void FixedUpdate() 
    {
        // ---- rotation vers mousePositionObject ----

        // Vector3 qui correspond à la direction en prenant la position du "mousePositionObject" et soustrait la position du player
        Vector3 direction = mousePositionObject.transform.position - transform.position;
        //Debug.Log("direction =" + direction);

        // renvoie une rotation créée par le devant actuel et la direction a pointer
        Quaternion toRotation = Quaternion.LookRotation(transform.forward, direction);
        Debug.Log("toRotation =" + toRotation);

        // /!\ en chantier /!\ mais grosso modo ça tourne le joueur vers la rotation créée plus haut
        //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1 * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1 * Time.deltaTime);
        //transform.LookAt(mousePositionObject.transform);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 100f, 0.0f), 1 * Time.deltaTime);


        // ---- déplacement vers mousePositionObject ----

        // ˯˯bonne ligne pour le déplacement
        //transform.position = Vector3.MoveTowards(transform.position, mousePositionObject.transform.position, (speed / 10) );
        
        // ˯˯ligne pour le déplacement modifié
        transform.position = Vector3.MoveTowards(transform.position, direction, (speed / 10) );
        

        // ---- accélération et décélération ---- 

        if (Input.GetKey("space"))
        {
            // tant que espace est préssé, "speed" augmente lentement vers "maxSpeed" à la vitesse de 3 * Time.deltaTime
            speed = Mathf.SmoothStep(speed, maxSpeed, 3 * Time.deltaTime);
        }
        else if (Input.GetKey("space") == false)
        {
            // tant que espace n'est pas préssé, "speed" devient lentement 0 à la vitesse de 8 * Time.deltaTime
            speed = Mathf.SmoothStep(speed, 0f, 8 * Time.deltaTime);
        }

    }
}
