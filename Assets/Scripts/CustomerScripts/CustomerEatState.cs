using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEatState : CustomerBaseState
{

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Eating...");

    }

    public override void UpdateState(CustomerStateManager customer)
    {

    }

    public override void OnCollisionEnter(CustomerStateManager customer)
    {

    }

    public override void OnTriggerStay(CustomerStateManager customer, Collider collider)
    {

    }

    private void GenerateOrder(Dish dish)
    {

    }


}
