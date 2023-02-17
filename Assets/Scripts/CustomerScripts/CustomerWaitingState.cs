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

        customer.timer.fillAmount = 1;
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        currenTime -= 1 * Time.deltaTime;

        customer.timer.color = Color.Lerp(Color.red, Color.green, currenTime / startTime);
        customer.timer.fillAmount = currenTime / startTime;

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
