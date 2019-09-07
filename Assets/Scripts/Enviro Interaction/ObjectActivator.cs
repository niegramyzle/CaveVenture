using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour 
{
    [SerializeField] private float maxActivateDistance;
    [SerializeField] private Transform camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TryActivateObjectFromRay();
        }
    }    

    private void TryActivateObjectFromRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit, maxActivateDistance))
        {
            IInteractableObject interactableObject = hit.collider.gameObject.GetComponentInParent<IInteractableObject>();

            if (interactableObject != null)
            {
                interactableObject.OnObjectClick();
            }
        }
    }
}