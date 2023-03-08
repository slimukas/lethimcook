using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    // [SerializeField] private Camera pcCamera;

    private void LateUpdate()
    {
        // transform.LookAt(transform.position + pcCamera.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
