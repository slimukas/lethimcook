using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderState : CustomerBaseState
{
    private Dish dish;
    private CustomerOrder ingredient;
    private OrderTicket orderTicket;

    private bool isImportant;
    private int previousImportant = -1;
    private int numberOfToppings;
    private int numberOfImportantIng;
    private int orderLength;

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log("Ordering...");
        customer.hadOrdered = true;
        ingredient = customer.gameObject.GetComponent(typeof(CustomerOrder)) as CustomerOrder;
        orderTicket = customer.gameObject.GetComponent(typeof(OrderTicket)) as OrderTicket;

        dish = customer.GetMenu();
        GenerateOrder(dish);
        customer.SetState(CustomerState.Waiting);
        orderTicket.GenerateTicket();
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
        numberOfToppings = Random.Range(1, dish.maxToppings + 1);
        numberOfImportantIng = dish.importantIngredients.importantIngredient.Count;
        orderLength = numberOfToppings + numberOfImportantIng;

        for (int i = 0; i < orderLength; i++)
        {
            if (numberOfImportantIng != 0)
            {
                AddImportant(i);
            }
            else
            {
                if (numberOfToppings > 0)
                {
                    ingredient.order.Add(dish.availableIngredients[Random.Range(0, dish.availableIngredients.Length)].gameObject);
                    numberOfToppings--;
                }
            }
        }
    }

    private void AddImportant(int i)
    {
        for (int j = 0; j < numberOfImportantIng; j++)
        {
            bool isImportant = false;
            if (i == dish.importantIngredients.importantIngredient[j].priority && dish.importantIngredients.importantIngredient[j].priority != previousImportant)
            {
                previousImportant = dish.importantIngredients.importantIngredient[j].priority;
                isImportant = true;
            }
            if (isImportant)
            {
                ingredient.order.Add(dish.importantIngredients.importantIngredient[j].ingredient);
                break;
            }
            //final check
            else if (i == orderLength - 1)
            {
                AddLeftImportant();
                break;
            }
            //if no important ingredients should be for this slot
            else if (j == numberOfImportantIng - 1 && !isImportant && numberOfToppings > 0)
            {
                ingredient.order.Add(dish.availableIngredients[Random.Range(0, dish.availableIngredients.Length)].gameObject);
                numberOfToppings--;
                break;
            }
        }
    }

    private void AddLeftImportant()
    {
        for (int k = 0; k < numberOfImportantIng; k++)
        {
            if (orderLength - 1 <= dish.importantIngredients.importantIngredient[k].priority)
            {
                ingredient.order.Add(dish.importantIngredients.importantIngredient[k].ingredient);
            }
        }
    }



}
