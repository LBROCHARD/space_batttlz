using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health = 0f; //PV du joueur
    public float maxHealth = 100f; //PV maximaux
    public float testDamage = 10f; //dégats de test
    
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = maxHealth;
        healthBar.SetHealthBarValue(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("t"))
        {
            health -= testDamage;
            healthBar.SetHealthBarValue(health);
        }

        if(health <= 0)
        {
            gameManager.Decede();
        }
    }

}
