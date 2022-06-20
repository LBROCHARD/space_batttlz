using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool estMort = false;
    public Deathscreen Deathscreen;
    public GameObject player;
    public MeshRenderer invisible;
    public MeshCollider playerCollider;

    private Vector3 spawnposition;

    void Start()
    {
        spawnposition = new Vector3(0.0f, 1.0f, 0.0f);
        invisible = player.GetComponent<MeshRenderer>();
        playerCollider = player.GetComponent<MeshCollider>();
        invisible.enabled = true;
        playerCollider.enabled = true;
    }

    void FixedUpdate()
    {
        if(estMort)
        {
            player.transform.position = spawnposition;
        }
    }

    public void Decede()
    {
        if(estMort == false){
            Deathscreen.Setup();
            invisible.enabled = false;
            playerCollider.enabled = false;
            estMort = true;
        }
    }

    public void Respawn()
    {
        invisible.enabled = true;
        playerCollider.enabled = true;
        Deathscreen.QuitScreen();
        estMort = false;
    }
}
