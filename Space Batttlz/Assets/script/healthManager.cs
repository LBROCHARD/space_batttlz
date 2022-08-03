using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    bool estMort = false;

    public float health = 0f; //PV du joueur
    public float maxHealth = 100f; //PV maximaux
    public float testDamage = 10f; //dégats de test

    public Deathscreen deathscreen;
    public HealthManager healthManager;
    public GameObject player;
    public MeshRenderer invisible;
    public MeshCollider playerCollider;

    private Vector3 spawnposition;

    // Start is called before the first frame update
    void Start()
    {
        deathscreen = GameObject.Find("DeathBackground").GetComponent<Deathscreen>();
        deathscreen.playerHelathManager = GetComponent<HealthManager>();
        spawnposition = new Vector3(0.0f, 1.0f, 0.0f);

        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = maxHealth;
        healthBar.SetHealthBarValue(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(estMort)
        {
            player.transform.position = spawnposition;
        }

        if(Input.GetKeyDown("t"))
        {
            health -= testDamage;
            healthBar.SetHealthBarValue(health);
        }

        if(health <= 0)
        {
            Decede();
        }
    }

    public void Decede()
    {
        if(estMort == false){
            deathscreen.Setup();
            invisible.enabled = false;
            playerCollider.enabled = false;
            estMort = true;
        }
    }

    public void Respawn()
    {
        healthManager.health = healthManager.maxHealth;
        estMort = false;
        invisible.enabled = true;
        playerCollider.enabled = true;
        deathscreen.QuitScreen();
    }

}
