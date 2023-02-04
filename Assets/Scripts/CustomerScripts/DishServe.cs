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

        if (other.gameObject.tag == "Plate")
        {
            GetPlateIngr(other.gameObject);
            ingredient.preparedOrder = plateIngr;
            customer.SetState(CustomerState.Eating);
        }
    }

    void GetPlateIngr(GameObject plate)
    {
        plateIngr = plate.GetComponentInChildren<PlateAssemble>().onPlateObj;
    }
}
