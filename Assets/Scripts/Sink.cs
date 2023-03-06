using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    [SerializeField] private ParticleSystem cleanVFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlateStates>() != null)
        {
            other.gameObject.GetComponent<PlateStates>().Clean();
            cleanVFX.Play();
        }
    }
}
