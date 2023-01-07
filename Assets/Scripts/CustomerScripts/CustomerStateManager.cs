using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{
    [SerializeField] private Menu dish;
    CustomerBaseState currentState;
    public CustomerWaitingState WaitingState = new CustomerWaitingState();
    public CustomerOrderState OrderingState = new CustomerOrderState();
    public CustomerEatState EatingState = new CustomerEatState();

    void Start()
    {
        currentState = WaitingState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(this, other);
    }

    public void SwitchState(CustomerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public Dish GiveMenu()
    {
        return dish.dish[Random.Range(0, dish.dish.Length)];
    }
}