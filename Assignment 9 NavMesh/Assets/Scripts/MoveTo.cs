﻿/*
 * (Gavin Worley)
 * (Assignment 9)
 * (Brief description of the code in the file.
 *  Used to move the player towards its goal)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform goal;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
