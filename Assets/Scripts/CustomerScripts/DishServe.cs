using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishServe : MonoBehaviour
{
    [SerializeField] GameObject[] plateIngr;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plate")
        {

            other.transform.parent = transform;
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localPosition = new Vector3(0, 0, 0);

            GetPlateIngr(other.gameObject);
        }
    }

    void GetPlateIngr(GameObject plate)
    {
    }
}
