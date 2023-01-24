using UnityEngine;

public enum CustomerState { Waiting, Ordering, Eating }

public class CustomerStateManager : MonoBehaviour
{
    // Serialized Fields

    [SerializeField] private Menu menu; //? Kodel jis SerializedField?

    // Private fields

    private CustomerBaseState currentState;

    // Properties

    public CustomerOrder CustomerOrder { get; private set; }
    public OrderTicket OrderTicket { get; private set; }


    public Dish GetMenu()
    {
        return menu.dish[Random.Range(0, menu.dish.Length)];
    }

    public void SetState(CustomerState state)
    {
        CustomerBaseState newState = null;

        switch (state)
        {
            case CustomerState.Waiting:
                newState = new CustomerWaitingState();
                break;
            case CustomerState.Ordering:
                newState = new CustomerOrderState();
                break;
            case CustomerState.Eating:
                newState = new CustomerEatState();
                break;
        }

        if (newState != null)
        {
            currentState = newState;
            currentState.EnterState(this);
        }
    }

    // MonoBehaviour
    private void Awake()
    {
        CustomerOrder = GetComponentInChildren<CustomerOrder>();
        OrderTicket = GetComponentInChildren<OrderTicket>();

        SetState(CustomerState.Waiting);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(this, other);
    }

}