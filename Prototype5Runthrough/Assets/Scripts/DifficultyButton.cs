/*
 * (Gavin Worley)
 * (Prototype 5)
 * (Brief description of the code in the file.
 *  allows the player to set a difficulty)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;

    private GameManager gameManager;

    public int difficulty;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

    }

    void SetDifficulty()
    {
        //Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
