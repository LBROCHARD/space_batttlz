using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public float rocketSpeed = 10f;
    Rigidbody rb;
    Collider rocketCollider;
    private bool justSpawned;
    public float afterSpawnNoCollideTime = 0.5f;

    void Start() // Start is called before the first frame update
    {
        justSpawned = true;
        rocketCollider = GetComponent<Collider>();
        rocketCollider.enabled = !rocketCollider.enabled; //désactive le collider de la rocket au moment où elle spawn (en inversant l'activation du collider)
    }

    void Update() // Update is called once per frame
    {
        if(justSpawned) { //réactive le collider de la rocket peu après son spawn (pour éviter de immédiatement collide avec le joueur)
            Wait(afterSpawnNoCollideTime);
            rocketCollider.enabled = !rocketCollider.enabled; //inverse l'activation du collider (le réactive ici)
        }
    }

    void FixedUpdate()
    {  //FAIRE ALLER LA ROCKET DROIT  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        transform.eulerAngles = new Vector3(90, transform.eulerAngles.y, 0);
        transform.position += transform.up * Time.deltaTime * (rocketSpeed / 10);
    }

    IEnumerator Wait(float duration) //met l'exéction 
    {
        yield return new WaitForSeconds(duration);
    }
}
