using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitingState : CustomerBaseState
{

    float startTime = 30;
    float currenTime = 0;
    bool hadOrdered;

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Waiting...");
        currenTime = startTime;
        hadOrdered = customer.hadOrdered;
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        currenTime -= 1 * Time.deltaTime;
        if (currenTime <= 0)
        {
            GameObject.Destroy(customer.gameObject);
        }
    }

    public override void OnCollisionEnter(CustomerStateManager customer)
    {

    }

    public override void OnTriggerStay(CustomerStateManager customer, Collider collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && hadOrdered == false)
        {
            customer.SetState(CustomerState.Ordering);
            hadOrdered = true;
        }
    }



}
