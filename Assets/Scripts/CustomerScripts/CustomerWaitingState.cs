using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerWaitingState : CustomerBaseState
{

    float startTime = 30;
    float currenTime = 0;
    bool hadOrdered;

    Sequence timerSequence = DOTween.Sequence();

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Waiting...");

        currenTime = startTime;
        hadOrdered = customer.hadOrdered;

        customer.timer.fillAmount = 1;
        TimerDisplay(customer, startTime);

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

    private void TimerDisplay(CustomerStateManager customer, float duration)
    {
        timerSequence.Kill();
        timerSequence.Append(customer.timer.DOFillAmount(0, duration))
        .Append(customer.timer.DOColor(Color.red, duration));


    }


}
