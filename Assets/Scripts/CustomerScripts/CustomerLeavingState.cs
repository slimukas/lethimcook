using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLeavingState : CustomerBaseState
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget = 5f;

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Leaving...");
        startPosition = customer.transform.localPosition;
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        t += Time.deltaTime / timeToReachTarget;
        customer.transform.localPosition = Vector3.Lerp(startPosition, customer.spawnPosition, t);

        if (customer.transform.localPosition == customer.spawnPosition)
        {
            GameObject.Destroy(customer.gameObject);
        }
    }

    public override void OnCollisionEnter(CustomerStateManager customer)
    {

    }

    public override void OnTriggerStay(CustomerStateManager customer, Collider collider)
    {

    }



}
