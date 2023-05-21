using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResSetter : MonoBehaviour
{
    [SerializeField] private int defaultWidth = 1280;
    [SerializeField] private int defaultHeight = 720;
    [SerializeField] private bool fullscreen = false;

    void Start()
    {
        Screen.SetResolution(defaultWidth, defaultHeight, fullscreen);

    }
}
