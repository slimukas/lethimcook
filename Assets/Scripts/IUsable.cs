using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable
{
    GameObject gameObject { get; }
    void Interact();
}
