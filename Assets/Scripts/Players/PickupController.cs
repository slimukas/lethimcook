using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] GameObject holdAreaObj;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] private float picupRange;
    [SerializeField] private float pickupForce;

    private Vector3 pickupDistance;

    private void Update()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, picupRange))
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
            MoveObject();
            pickupDistance = heldObj.transform.position - holdArea.transform.position;
            if (pickupDistance.magnitude >= 1.2)
            {
                DropObject();
                //Debug.Log(distance.magnitude);
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
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
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
