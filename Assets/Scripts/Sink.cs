using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterVFX;
    [SerializeField] private Animation sinkAniamtion;
    [SerializeField] private AudioSource sinkAudio;

    private void OnTriggerEnter(Collider other)
    {
        waterVFX.Play();
        sinkAniamtion.Play("Sink_Open");
        sinkAudio.Play();
        if (other.gameObject.GetComponent<PlateStates>() != null)
        {
            other.gameObject.GetComponent<PlateStates>().Clean();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        sinkAniamtion.Play("Sink_Close");
        sinkAudio.Stop();
        waterVFX.Stop();
        waterVFX.Clear();
    }
}
