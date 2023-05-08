using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] GameObject holdAreaObj;
    [SerializeField] GameObject pickuopUiElement;

    private GameObject heldObj;
    private Rigidbody heldObjRB;
    private bool rayHit;
    private float currentWeight;


    [Header("Physics Parameters")]
    [SerializeField] private float picupRange;
    [SerializeField] private float pickupForce;

    [SerializeField] private Animator animator;

    private Vector3 pickupDistance;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, picupRange)
        && hit.collider.GetComponent<Rigidbody>() != null)
        {
            Debug.Log(hit.collider.name);
            pickuopUiElement.SetActive(true);
            rayHit = true;
        }
        else
        {
            pickuopUiElement.SetActive(false);
            rayHit = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                if (rayHit)
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();


            }
        }
        else if (heldObj != null)
        {
            //heldObj.transform.localPosition = Vector3.zero;
            MoveObject();
            pickupDistance = heldObj.transform.position - holdArea.transform.position;
            if (pickupDistance.magnitude >= 1.2)
            {
                DropObject();
            }
        }

    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
            heldObjRB.transform.rotation = Quaternion.Slerp(heldObj.transform.rotation, new Quaternion(0, 0, 0, 0), 1);
        }
    }


    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            animator.SetLayerWeight(1, 1f);
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = true;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjRB.constraints = RigidbodyConstraints.FreezePosition;

            heldObjRB.transform.parent = holdArea;
            heldObjRB.transform.localPosition = Vector3.zero;
            heldObjRB.transform.localRotation = Quaternion.Euler(0, 0, 0);
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        animator.SetLayerWeight(1, 0f);
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        if (heldObjRB.transform.parent == holdAreaObj.transform)
        {
            heldObjRB.transform.parent = null;
        }
        heldObj = null;
    }

}
