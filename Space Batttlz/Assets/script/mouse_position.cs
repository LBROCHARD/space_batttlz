using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_position : MonoBehaviour
{

    // la serialisation (SerializeField) permet de modifier ce paramètre sur unity tout en le gardant privé
    // ajout d'une camera depuis laquelle on verifie la position de l'objet
    [SerializeField] private Camera camera;
    // et ajout d'un layer sur lequel se faire deplacer l'objet
    [SerializeField] private LayerMask layerMask;
    

    void Start() {
        
    }

    void Update() {

        // crée un nouveau rayon, qui part d'un point sur l'écran (ici, la position de la souris) vers l'équivalent dans le monde en 3D
        Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);

        // si le rayon "mouseRay" touche un objet dans le layer renseigné dans "layerMask"
        // (sachant qu'il renvoie l'emplacement où ça à touché dans "rayCastHit", et il vérifie jusqu'à la distance "float.MaxValue" (donc infini))
        if (Physics.Raycast(mouseRay, out RaycastHit raycastHit, float.MaxValue, layerMask)) {
            //deplace l'objet à l'emplacement où le rayon a touché
            transform.position = raycastHit.point;
        }

    }

}
