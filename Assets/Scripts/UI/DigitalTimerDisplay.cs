using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class DigitalTimerDisplay : MonoBehaviour
{
    private TMP_Text timerText;
    public CustomerOrder CustomerOrder { get; private set; }

    public event Action OnTimerEnd;

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        Game.Current.room.OnDoorOpened += StartTimer;
        var minutes = Mathf.FloorToInt(Game.Current.room.timer / 60);
        var seconds = Mathf.FloorToInt(Game.Current.room.timer - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator DisplayTimer()
    {
        while (Game.Current.room.timer > 0)
        {
            var minutes = Mathf.FloorToInt(Game.Current.room.timer / 60);
            var seconds = Mathf.FloorToInt(Game.Current.room.timer - minutes * 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return null;

        }
        if (Game.Current.room.timer <= 0)
        {
            OnTimerEnd?.Invoke();
        }


    }

    private void StartTimer()
    {
        Debug.Log("Timer Start");
        StartCoroutine(DisplayTimer());
    }
}
