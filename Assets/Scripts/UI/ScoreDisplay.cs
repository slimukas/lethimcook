using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text scoreText;
    private bool canCountScore;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        canCountScore = false;
        Game.Current.room.OnDoorOpened += CanCountScore;
        scoreText.text = $" {Game.Current.room.score} / {Game.Current.room.neededScore}";
    }
    private void FixedUpdate()
    {
        if (canCountScore == false) return;
        scoreText.text = $" {Game.Current.room.score} / {Game.Current.room.neededScore}";
    }

    private void CanCountScore()
    {
        canCountScore = true;
    }
}
