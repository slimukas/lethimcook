using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Game.Current.pcCam;
    }
    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(cam.transform.forward);
    }
}
