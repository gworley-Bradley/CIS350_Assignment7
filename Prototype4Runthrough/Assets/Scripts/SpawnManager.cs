/*
 * (Gavin Worley)
 * (Prototype 4)
 * (Brief description of the code in the file.
 *  Used to handle the spawning of enemies and powerups)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public PlayerController playerControllerScript;
    public UIManager uiManager;

    private float spawnRange = 9;

    public int enemyCount;

    public int waveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 0;

        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        if (uiManager == null)
        {
            uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //instantiate the enemy in the random position
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup (int powerupstoSpawn)
    {
        for (int i = 0; i < powerupstoSpawn; i++)
        {
            //instantiate the enemy in the random position
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        //generating a random position on the platform
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            if (!uiManager.won || !playerControllerScript.gameOver)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                SpawnPowerup(1);
            }

        }
        
    }
    
}
