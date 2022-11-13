/*
 * (Gavin Worley)
 * (Challenge 4)
 * (Brief description of the code in the file.
 *  Used to show the UI to the player)
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

    public bool won;
    public int wave = 0;

    public SpawnManagerX spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        if (waveText == null)
        {
            waveText = GameObject.Find("waveText").GetComponent<Text>();
        }
        if (instructionText == null)
        {
            instructionText = GameObject.Find("instructionText").GetComponent<Text>();
        }
        if (spawnManager == null)
        {
            spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        wave = spawnManager.waveCount - 1;

        if (!spawnManager.gameOver)
        {
            waveText.text = "Wave: " + wave;
        }
        if (spawnManager.gameOver)
        {
            waveText.text = "You Lose!" + "\n" + "Press R to Try Again";
            Time.timeScale = 0;
        }

        if (wave > 10)
        {
            won = true;
            waveText.text = "You Win!" + "\n" + "Press R to Try Again!";
            Time.timeScale = 0;
        }

        if ((spawnManager.gameOver || won) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            Destroy(instructionText);
        }
    }
}
