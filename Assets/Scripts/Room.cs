using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Room : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private float minutes;
    [SerializeField] private float seconds;

    public event Action OnDoorOpened;
    public event Action OnDoorClose;

    public float timer { get; private set; }


    private void Awake()
    {
        timer = minutes * 60 + seconds;
    }

    public void OpenDoor()
    {
        door.localScale = Vector3.zero;
        OnDoorOpened?.Invoke();
        StartCoroutine(startTimer());
    }

    private IEnumerator startTimer()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        if (timer <= 0)
        {
            OnDoorClose?.Invoke();
        }
    }

}
