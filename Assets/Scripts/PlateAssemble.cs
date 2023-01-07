using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateAssemble : MonoBehaviour
{
    [Header("Ingredient place pivot")]
    [SerializeField] private Transform pivot;

    [Header("Ingredients on plate")]
    [SerializeField] private List<GameObject> onPlateObj;

    void Start()
    {
        onPlateObj = new List<GameObject>();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ingredient" && !onPlateObj.Contains(other.gameObject))
        {

            other.transform.parent = transform;
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;

            other.transform.localPosition = pivot.transform.localPosition;
            pivot.transform.localPosition = new Vector3(transform.localPosition.x, pivot.transform.localPosition.y + other.GetComponent<IngredientParam>().Height(), transform.localPosition.z);
            onPlateObj.Add(other.gameObject);

        }
    }



}
