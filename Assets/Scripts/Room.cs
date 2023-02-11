using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Room : MonoBehaviour
{
    public Transform door;

    public event Action OnDoorOpened;

    public void OpenDoor()
    {
        door.localScale = Vector3.zero;
        OnDoorOpened?.Invoke();
    }

}
