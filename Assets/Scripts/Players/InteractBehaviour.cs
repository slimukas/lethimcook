using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    [SerializeField] private float interactRange;
    [SerializeField] private GameObject interactIcon;
    [SerializeField] private Transform Camera;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Camera.transform.TransformDirection(Vector3.forward), out hit, interactRange))
        {
            var objectToInteractWith = hit.collider.gameObject;
            if (hit.collider.gameObject.TryGetComponent(out IUsable interactableObject) && interactableObject.canInteract)
            {
                interactIcon.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactableObject.Interact();
                }
            }
            else
            {
                interactIcon.SetActive(false);

            }
        }
        else
        {
            interactIcon.SetActive(false);
        }
    }

}
