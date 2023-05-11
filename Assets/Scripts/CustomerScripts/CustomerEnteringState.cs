using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEnteringState : CustomerBaseState
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Entering...");

        timeToReachTarget = Random.Range(4.5f, 6f);
        startPosition = customer.startPosition;
        target = new Vector3(0, 0, 0);
        customer.canInteract = false;
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        t += Time.deltaTime / timeToReachTarget;
        customer.transform.localPosition = Vector3.Lerp(startPosition, target, t);

        if (customer.transform.localPosition == target)
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
