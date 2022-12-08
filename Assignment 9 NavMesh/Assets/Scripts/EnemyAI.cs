/*
 * (Gavin Worley)
 * (Assignment 9)
 * (Brief description of the code in the file.
 *  EnemyAI, used to control the enemy)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class EnemyAI : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public GameObject Player;
    public float chaseDistance;

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        Player = GameObject.FindGameObjectWithTag("Player");
        agent.updateRotation = false;
        chaseDistance = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {


        float distanceFromTarget = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceFromTarget > agent.stoppingDistance && distanceFromTarget < chaseDistance)
        {
            agent.SetDestination(Player.transform.position);
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            agent.SetDestination(transform.position);
            character.Move(Vector3.zero, false, false);
        }
    }
}

