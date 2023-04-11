using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitingState : CustomerBaseState
{

    float waitTime;
    float currenTime = 0;
    bool hadOrdered;
    bool isLeaving;

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Waiting...");
        waitTime = customer.waitTime;
        currenTime = waitTime;
        hadOrdered = customer.hadOrdered;

        customer.timer.fillAmount = 1;
        isLeaving = false;
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        currenTime -= 1 * Time.deltaTime;

        customer.timer.color = Color.Lerp(Color.red, Color.green, currenTime / waitTime);
        customer.timer.fillAmount = currenTime / waitTime;

        if (currenTime <= 0 && isLeaving == false)
        {
            isLeaving = true;
            customer.leaveVFX.Play();
            customer.model.SetActive(false);
            GameObject.Destroy(customer.gameObject, 0.5f);
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
