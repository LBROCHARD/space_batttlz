using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{
    [SerializeField] private float health = 0f; //PV du joueur
    [SerializeField] private float maxHealth = 100f; //PV maximaux
    [SerializeField] private float testDamage = 10f; //dégats de test

    // Start is called before the first frame update
    void Start()
    {
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
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Mort !");
        Destroy(gameObject);
    }
}
