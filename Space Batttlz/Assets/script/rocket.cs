using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class rocket : NetworkBehaviour
{
    [SyncVar] public uint parentID;

    public float rocketSpeed = 10f;
    Collider rocketCollider;
    public float afterSpawnNoCollideTime = 0.5f; // temps passé sans detecter les collisions
    private ParticleSystem rocketParticle;

    private bool canMove = true;
    private float timeBeforePerish = 0f;

    // void Start()
    // {
    //     rocketParticle = GetComponent<ParticleSystem>();
    //     rocketParticle.Stop();
    //     Debug.Log("Start()");
    // }
    public void Awake()
    {
        rocketParticle = GetComponent<ParticleSystem>();
        rocketParticle.Stop();
        // rocketCollider = GetComponent<Collider>();
        // rocketCollider.enabled = false; //désactive le collider de la rocket au moment où elle spawn
        // StartCoroutine(Wait_collider(afterSpawnNoCollideTime));
        Debug.Log("Awake()");
    }

    void Update()
    {
        //Debug.Log( "rotation =" +  toRotation);
    }

    void FixedUpdate()
    {  
        if ( canMove == true ) {
            transform.Translate (Vector3.up * Time.deltaTime * rocketSpeed);
        }

        if ( timeBeforePerish != 0 && timeBeforePerish <= Time.time ) {
            Destroy(gameObject);
            NetworkServer.Destroy(gameObject);
        }
    }

    // private IEnumerator Wait_collider(float duration) //met l'exéction 
    // {
    //     yield return new WaitForSeconds(duration);
    //     rocketCollider.enabled = true; //réactive l'activation du collider
    // }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "Player" ) {
            if (other.gameObject.GetComponent<player>().id != parentID ){
                Explode();
            }
        } else {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("Explode()");

        rocketParticle.Play();
        // Debug.Log("Collision !");
        canMove = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        timeBeforePerish = Time.time + 1f;
    }

    
}
