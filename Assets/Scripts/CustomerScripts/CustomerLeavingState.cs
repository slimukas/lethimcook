using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLeavingState : CustomerBaseState
{
    float t;
    Transform startPosition;
    float timeToReachTarget = 5f;

    public override void EnterState(CustomerStateManager customer)
    {
        customer.animator.SetTrigger("Walk");

        startPosition = customer.transform.parent.GetChild(0).transform;
        customer.timer.gameObject.SetActive(false);

    }

    public override void UpdateState(CustomerStateManager customer)
    {
        t += Time.deltaTime / timeToReachTarget;
        customer.transform.localPosition = Vector3.Lerp(new Vector3(0, 0, 0), startPosition.localPosition, t);
        customer.transform.LookAt(startPosition);
        if (customer.transform.localPosition == startPosition.localPosition)
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
