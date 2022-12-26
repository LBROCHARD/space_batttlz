using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool estMort = false;
    public Deathscreen Deathscreen;

    private HealthManager healthManager;
    public static GameObject localPlayer;
    private MeshRenderer invisible;
    private MeshCollider playerCollider;

    private Vector3 spawnposition;

    void Start()
    {
        localPlayer = GameObject.Find("Player");
        spawnposition = new Vector3(0.0f, 1.0f, 0.0f);
    }

    void FixedUpdate()
    {
        if(estMort)
        {
            localPlayer.transform.position = spawnposition;
        }
    }

    public void SetupPlayer(GameObject _player)
    {
        localPlayer = _player;
        healthManager = localPlayer.GetComponentInChildren<HealthManager>();
        invisible = localPlayer.GetComponent<MeshRenderer>();
        playerCollider = localPlayer.GetComponent<MeshCollider>();
        invisible.enabled = true;
        playerCollider.enabled = true;
    }

    public void Decede()
    {
        if(estMort == false)
        {
            Deathscreen.Setup();
            invisible.enabled = false;
            playerCollider.enabled = false;
            estMort = true;
        }
    }

    public void Respawn()
    {
        healthManager.Respawn();
        estMort = false;
        invisible.enabled = true;
        playerCollider.enabled = true;
        Deathscreen.QuitScreen();
    }
}

