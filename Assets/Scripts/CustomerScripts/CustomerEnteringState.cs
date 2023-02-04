using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEnteringState : CustomerBaseState
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget = 5f;

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Entering...");
        startPosition = customer.startPosition;
        target = new Vector3(0, customer.transform.position.y, 0);
        Debug.Log(target);
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
