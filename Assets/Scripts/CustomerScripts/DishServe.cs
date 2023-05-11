using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishServe : MonoBehaviour
{
    [SerializeField] private List<GameObject> plateIngr;
    [SerializeField] private CustomerStateManager customer;

    public CustomerOrder ingredient;

    void OnTriggerEnter(Collider other)
    {
        ingredient = customer.gameObject.GetComponent(typeof(CustomerOrder)) as CustomerOrder;

        if (other.gameObject.tag == "Plate" && other.GetComponent<PlateStates>().isClean == true)
        {
            if (customer.hadOrdered)
            {
                GetPlateIngr(other.gameObject);
                ingredient.preparedOrder = plateIngr;
                other.GetComponent<PlateStates>().Dirty();
                customer.SetState(CustomerState.Eating);
            }
        }
        else if (other.gameObject.tag == "Drink")
        {
            Destroy(other.gameObject);
            customer.SetState(CustomerState.Waiting);
        }
    }

    void GetPlateIngr(GameObject plate)
    {
        plateIngr = plate.GetComponentInChildren<PlateAssemble>().onPlateObj;
    }
}
