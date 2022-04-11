using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public float rocketSpeed = 10f;
    Collider rocketCollider;
    public float afterSpawnNoCollideTime = 0.5f;
    private ParticleSystem rocketParticle;

    private bool canMove = true;
    private float timeBeforePerish = 0f;

    void Start() // Start is called before the first frame update
    {
        rocketParticle = GetComponent<ParticleSystem>();
        rocketParticle.Stop();
        rocketCollider = GetComponent<Collider>();
        rocketCollider.enabled = false; //désactive le collider de la rocket au moment où elle spawn
        StartCoroutine(Wait_collider(afterSpawnNoCollideTime));
    }

    void Update() // Update is called once per frame
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
        }

    }

    private IEnumerator Wait_collider(float duration) //met l'exéction 
    {
        yield return new WaitForSeconds(duration);
        rocketCollider.enabled = true; //réactive l'activation du collider
    }

    private void OnTriggerEnter(Collider other)
    {
        rocketParticle.Play();
        Debug.Log("Collision !");
        canMove = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        timeBeforePerish = Time.time + 1f;
    }

    
}
