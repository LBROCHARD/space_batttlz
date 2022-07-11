using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

// permet de désactiver le contrôle des autres joueurs
public class OnlineSetup : NetworkBehaviour
{
    // liste de composents à désactiver si le joeur n'est pas le joueur local
    [SerializeField]
    Behaviour[] componentsToDisable;

    void Start() 
    {
        if (!isLocalPlayer)
        {
            foreach (var component in componentsToDisable)
            {
                component.enabled = false;
            }
        }
        else
        {
            GetComponent<player>().EnableCameraAndMousePosition();
            GetComponent<player>().isMovingEnabled = true;
        }
    }
}
