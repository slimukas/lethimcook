using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterVFX;
    [SerializeField] private Animation sinkAniamtion;

    private void OnTriggerEnter(Collider other)
    {
        waterVFX.Play();
        sinkAniamtion.Play("Sink_Open");
        if (other.gameObject.GetComponent<PlateStates>() != null)
        {
            other.gameObject.GetComponent<PlateStates>().Clean();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        sinkAniamtion.Play("Sink_Close");
        waterVFX.Stop();
        waterVFX.Clear();
    }
}
