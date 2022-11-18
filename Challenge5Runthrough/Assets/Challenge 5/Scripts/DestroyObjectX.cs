/*
 * (Gavin Worley)
 * (Challenge 5)
 * (Brief description of the code in the file.
 *  used to destroy the object particle after 2 seconds)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2); // destroy particle after 2 seconds
    }


}
