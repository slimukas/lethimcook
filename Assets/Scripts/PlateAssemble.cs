using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateAssemble : MonoBehaviour
{
    [SerializeField] private Vector3 pivot;
    private Vector3 firstPosition;
    private Vector3 nextPosition;

    [Header("Ingredients on plate")]
    public List<GameObject> onPlateObj;

    void Start()
    {
        onPlateObj = new List<GameObject>();
        firstPosition = pivot;
        nextPosition = firstPosition;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ingredient" && !onPlateObj.Contains(other.gameObject))
        {
            Vector3 size;
            onPlateObj.RemoveAll(item => item == null);
            onPlateObj.Add(other.gameObject);
            other.transform.parent = transform;
            other.GetComponent<Rigidbody>().isKinematic = true;

            if (onPlateObj.Count <= 1)
            {
                size = other.transform.localScale;
                other.transform.localPosition = new Vector3(firstPosition.x, firstPosition.y + (size.y / 2), firstPosition.z);
                other.transform.localRotation = new Quaternion(0, 0, 0, 0);

                nextPosition = new Vector3(firstPosition.x, firstPosition.y + size.y, firstPosition.z);
                Debug.Log(nextPosition.ToString());

            }

            else
            {
                size = other.transform.localScale;


                other.transform.localPosition = new Vector3(nextPosition.x, nextPosition.y + (size.y / 2), nextPosition.z);
                other.transform.localRotation = new Quaternion(0, 0, 0, 0);

                nextPosition = new Vector3(nextPosition.x, nextPosition.y + size.y, nextPosition.z); ;
            }

        }



    }
}



