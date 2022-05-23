using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    bool estMort = false;
    public Deathscreen Deathscreen;
    public GameObject player;

    public void Decede()
    {
        if(estMort == false){
            estMort = true;
            Deathscreen.Setup();
            Destroy(player);
        }
        
    }
}
