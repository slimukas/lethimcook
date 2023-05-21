using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEnteringState : CustomerBaseState
{
    float t;
    Vector3 startPosition;
    Transform target;
    float timeToReachTarget;

    public override void EnterState(CustomerStateManager customer)
    {
        customer.animator.SetTrigger("Walk");

        timeToReachTarget = Random.Range(4.5f, 6f);
        startPosition = customer.startPosition;
        target = customer.transform.parent.transform;
        customer.canInteract = false;
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        t += Time.deltaTime / timeToReachTarget;
        customer.transform.localPosition = Vector3.Lerp(startPosition, new Vector3(0, 0, 0), t);
        customer.transform.LookAt(target);
        if (customer.transform.localPosition == new Vector3(0, 0, 0))
        {
            customer.SetState(CustomerState.Waiting);
        }
    }

    public override void OnCollisionEnter(CustomerStateManager customer)
    {

    }

    public override void OnTriggerStay(CustomerStateManager customer, Collider collider)
    {

    }



}
