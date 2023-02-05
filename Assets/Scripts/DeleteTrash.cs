using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTrash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DeleteParam>() != null)
        {
            if (other.gameObject.GetComponent<DeleteParam>().canDelete == true)
                GameObject.Destroy(other.gameObject);
        }
    }
}
