using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishServe : MonoBehaviour
{
    [SerializeField] private List<GameObject> plateIngr;
    [SerializeField] private CustomerStateManager customer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plate")
        {

            other.transform.parent = transform;
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.transform.localRotation = new Quaternion(0, 0, 0, 0);

            GetPlateIngr(other.gameObject);
            customer.SwitchState(customer.EatingState);
        }
    }

    void GetPlateIngr(GameObject plate)
    {
        plateIngr = plate.GetComponentInChildren<PlateAssemble>().onPlateObj;
    }
}
