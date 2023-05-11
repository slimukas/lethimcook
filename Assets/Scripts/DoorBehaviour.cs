using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IUsable
{
    [SerializeField] private Room room;
    public bool canInteract { get; set; }

    private void Awake()
    {
        canInteract = true;
    }
    public void Interact()
    {
        if (canInteract)
        {
            room.OpenDoor();
        }

    }

}
