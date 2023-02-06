using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlateStates>() != null)
        {
            other.gameObject.GetComponent<PlateStates>().Clean();
        }
    }
}
