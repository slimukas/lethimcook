using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWalkingState : CustomerBaseState
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget = 5f;

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Walking...");
        startPosition = customer.transform.localPosition;
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        t += Time.deltaTime / timeToReachTarget;
        customer.transform.localPosition = Vector3.Lerp(startPosition, new Vector3(0, 0, 0), t);

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
