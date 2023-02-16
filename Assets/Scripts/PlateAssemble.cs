using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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

            Destroy(other.GetComponent<XRGrabInteractable>());
            other.transform.parent = transform;
            other.GetComponent<Rigidbody>().isKinematic = true;

            if (onPlateObj.Count <= 1)
            {
                size = other.GetComponent<BoxCollider>().size;
                other.transform.localPosition = new Vector3(firstPosition.x, firstPosition.y + 0.1f, firstPosition.z);
                other.transform.localRotation = new Quaternion(0, 0, 0, 0);

                nextPosition = new Vector3(firstPosition.x, firstPosition.y + (size.y / 2) + 0.1f, firstPosition.z);
                Debug.Log(nextPosition.ToString());

            }

            else
            {
                size = other.GetComponent<BoxCollider>().size;



                other.transform.localPosition = new Vector3(nextPosition.x, nextPosition.y, nextPosition.z);
                other.transform.localRotation = new Quaternion(0, 0, 0, 0);

                nextPosition = new Vector3(nextPosition.x, nextPosition.y + (size.y / 2), nextPosition.z);
                Debug.Log(nextPosition.ToString());

            }

        }



    }
}



