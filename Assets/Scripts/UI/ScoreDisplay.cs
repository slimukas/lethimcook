using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text roundEndText;
    [SerializeField] private ReadyPlayers scene;
    [SerializeField] private GameObject readyScreen;
    [SerializeField] private GameObject vrButton;
    [SerializeField] private ParticleSystem victoryVFX;
    private bool canCountScore;

    private void Start()
    {
        canCountScore = false;
        readyScreen.SetActive(false);
        Game.Current.room.OnDoorOpened += CanCountScore;
        scoreText.text = $" {Game.Current.room.score} / {Game.Current.room.neededScore}";
        Game.Current.room.OnDoorClose += DisplayScore;
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

    private void DisplayScore()
    {
        readyScreen.SetActive(true);
        vrButton.SetActive(true);
        if (Game.Current.room.neededScore >= Game.Current.room.score)
        {
            scoreText.color = Color.green;
            roundEndText.text = "Ready up for next level";
            victoryVFX.Play();
        }
        else
        {
            scoreText.color = Color.red;
            roundEndText.text = "Ready up to restart level";
            scene.scene = SceneManager.GetActiveScene().buildIndex;
        }

    }
}
