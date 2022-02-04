using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_position : MonoBehaviour
{

    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask layerMask;

    void Start() {
        
    }

    void Update() {

        Ray mouse_ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouse_ray, out RaycastHit raycastHit, float.MaxValue, layerMask)) {
            transform.position = raycastHit.point;
        }

    }

}
