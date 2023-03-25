using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IUsable
{
    [SerializeField] Room room;

    public void Interact()
    {
        room.OpenDoor();
    }

}
