/*
 * (Gavin Worley)
 * (Challenge 5)
 * (Brief description of the code in the file.
 *  Countdown timer for ending game)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownTimer : MonoBehaviour
{
    private GameManagerX gameManager;

    public float timeLeft = 60.0f;
    public Text startText; // used for showing countdown

    public bool timerStarted = false;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }
    void Update()
    {
        if (timerStarted)
        {
            timeLeft -= Time.deltaTime;
            // Convert integer to string
            startText.text = "Time Left: " + (timeLeft).ToString("0");
            if (timeLeft < 1 || !gameManager.isGameActive)
            {
                startText.text = "Time Left: 0";
                gameManager.GameOver();
            }
        }

    }

    public void StartTimer()
    {
        timerStarted = true;
    }
}