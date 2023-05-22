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

        if (other.tag == "Plate" && other.GetComponent<PlateStates>().isClean == true && other.transform.parent == null)
        {
            if (customer.hadOrdered)
            {
                customer.animator.SetTrigger("Eating");
                other.transform.parent = transform;
                other.transform.localPosition = new Vector3(0, 0.07f, 0);
                other.transform.rotation = new Quaternion(0, 0, 0, 0);
                StartCoroutine(PlatePrep(other));
            }
        }
        else if (other.gameObject.tag == "Drink")
        {
            Destroy(other.gameObject);
            customer.isMad = false;
            customer.SetState(CustomerState.Waiting);
        }
    }

    void GetPlateIngr(GameObject plate)
    {
        plateIngr = plate.GetComponentInChildren<PlateAssemble>().onPlateObj;
    }

    private IEnumerator PlatePrep(Collider other)
    {
        other.transform.parent = null;
        yield return new WaitForSeconds(2f);
        GetPlateIngr(other.gameObject);
        ingredient.preparedOrder = plateIngr;
        other.GetComponent<PlateStates>().Dirty();
        customer.SetState(CustomerState.Eating);
    }

}
