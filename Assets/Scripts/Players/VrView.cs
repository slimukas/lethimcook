using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VrView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        XRSettings.showDeviceView = false;
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
        // Check if additional displays are available and activate each.

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
