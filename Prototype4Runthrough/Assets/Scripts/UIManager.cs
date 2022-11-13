/*
 * (Gavin Worley)
 * (Challenge 3)
 * (Brief description of the code in the file.
 *  Used to show player the score and game decisions)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Text waveText;
    public Text instructionText;
    public PlayerController playerControllerScript;
    public SpawnManager spawnManager;
    public bool won = false;
    public bool start = false;


    // Start is called before the first frame update
    void Start()
    {

        if (waveText == null)
        {
            waveText = GameObject.Find("waveText").GetComponent<Text>();
        }
        if (instructionText == null)
        {
            instructionText = GameObject.Find("instructionText").GetComponent<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        if (spawnManager == null)
        {
            spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        }

        waveText.text = "Wave: 0";

    }

    // Update is called once per frame
    void Update()
    {
        //If the game is not over display the score
        if (!playerControllerScript.gameOver)
        {
            waveText.text = "Wave: " + spawnManager.waveNumber;
        }
        //If the game is over and the player has not won
        if (playerControllerScript.gameOver && !won)
        {
            waveText.text = "You Lose!" + "\n" + "Press R to Try Again";
        }
        //if the players wave is >10 player wins
        if (spawnManager.waveNumber > 10)
        {
            //playerControllerScript.gameOver = true;
            won = true;

            // playerControllerScript.StopRunning();

            waveText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }
        //Allows the player to restart the game
        if ((playerControllerScript.gameOver || won ) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            Destroy(instructionText);
            start = true;
        }
        //Allows the player to restart the game
        /* if (won && Input.GetKeyDown(KeyCode.R))
         {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }*/
    }
}