using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // référence au vaisseau
    public GameObject playerObject;
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

        // Vector3 qui correspond à la direction en prenant la position du "mousePositionObject" et soustrait la position du player
        //Vector3 direction = mousePositionObject.transform.position - transform.position;
        //Debug.Log("direction =" + direction);
        // renvoie une rotation créée par le devant actuel et la direction a pointer
        //Quaternion toRotation = Quaternion.LookRotation(transform.forward, direction);
        // Debug.Log( "dir =" + direction + "forwrd =" + transform.forward + "toRotation =" + toRotation);
        // /!\ en chantier /!\ mais grosso modo ça tourne le joueur vers la rotation créée plus haut
        //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1 * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1 * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 100f, 0.0f), 1 * Time.deltaTime);

        // calcule la différence entre la position du "mousePositionObject" et du player

        Quaternion toRotation = Quaternion.LookRotation(mousePositionObject.transform.position - playerObject.transform.position);
        //toRotation.Set(0, toRotation.y, toRotation.z, toRotation.w);

        // tourne vers "toRotation"
        playerObject.transform.rotation = Quaternion.RotateTowards(playerObject.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        //ligne qui fonctionne pour se tourner d'un coup vers l'objet
        //transform.LookAt(mousePositionObject.transform);


        // ---- déplacement vers mousePositionObject ----

        // bonne ligne pour le déplacement
        //transform.position = Vector3.MoveTowards(transform.position, mousePositionObject.transform.position, (speed / 10) );
        
        // create a forward vector
        // Vector3 forward = playerObject.transform.position + playerObject.transform.forward;
        Vector3 forward = transform.position + playerObject.transform.forward;
        Vector3 betterForward = new Vector3(forward.x, 10f, forward.z);
        // Debug.Log( "forward =" + forward );
        Debug.Log( "betterForward =" + betterForward );


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
