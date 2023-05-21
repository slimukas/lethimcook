using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Room room;
    public Camera pcCam;

    public static Game Current { get; private set; }

    private void Awake()
    {
        Current = this;
    }
}
