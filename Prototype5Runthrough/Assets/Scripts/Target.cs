using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public int pointValue;

    private GameManager gameManager;

    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {

        targetRb = GetComponent<Rigidbody>();
        RandomForce();
        RandomTorque();

        //set the position with a randomized X value
        transform.position = RandomSpawnPos();

        //set reference to gameManager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();


    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void RandomTorque()
    {

        //add a torque (rotational force) with randomized xyz values
        targetRb.AddTorque(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), 
            Random.Range(-maxTorque, maxTorque), ForceMode.Impulse);
    }

    private void RandomForce()
    {
        //add a force upwards multiplied by a randomized speed
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
             gameManager.GameOver();
        }

        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
