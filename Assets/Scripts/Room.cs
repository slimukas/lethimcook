using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class Room : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private int score;


    private int minutes;
    private int seconds;

    public event Action OnDoorOpened;
    public event Action OnDoorClose;

    public float timer { get; private set; }

#if UNITY_EDITOR
    [CustomEditor(typeof(Room))]
    public class RoomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Room room = (Room)target;
            EditorGUILayout.LabelField("Level duration");
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 50;
            room.minutes = EditorGUILayout.IntField("Minutes", room.minutes);
            room.seconds = EditorGUILayout.IntField("Seconds", room.seconds);
            EditorGUILayout.EndHorizontal();

        }
    }
#endif


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

    public void AddScore(int value)
    {
        score += value;
    }


}
