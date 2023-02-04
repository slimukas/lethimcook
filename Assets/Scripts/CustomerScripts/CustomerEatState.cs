using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEatState : CustomerBaseState
{
    private CustomerOrder customerOrder;
    private int rating = 5;


    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Eating...");
        customerOrder = customer.gameObject.GetComponent(typeof(CustomerOrder)) as CustomerOrder;
        EvaluateDish(customerOrder);
        Debug.Log(rating);

        //EatFood(customerOrder);
        customer.SetState(CustomerState.Leaving);

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

    private void EvaluateDish(CustomerOrder customerOrder)
    {
        if (customerOrder.order.Count != customerOrder.preparedOrder.Count)
        {
            rating = 1;
        }
        else
        {
            for (int i = 0; i < customerOrder.order.Count; i++)
            {
                if (customerOrder.order[i].GetComponent<IngredientParam>().id != customerOrder.preparedOrder[i].GetComponent<IngredientParam>().id)
                {
                    rating--;
                }
            }
        }

    }

    private void EatFood(CustomerOrder customerOrder)
    {

    }
}
