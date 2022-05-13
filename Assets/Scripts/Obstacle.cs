using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 tempPosition;

    void Update()
    {
        //Getting the current position of the pipes and reposition them
        //a certain amount to the left 
        tempPosition = transform.position;
        tempPosition.x -= 0.01f;
        transform.position = tempPosition;

        //If the pipes get to a point they are repositioned
        if (transform.position.x <= -4)
        {
            RecycleObject();
        }

    }
    void RecycleObject()
    {
        // The pipes are set at a random Y position everytime they respawn at their initial location
        float randomYposition = Random.Range(-2.5f, 2.5f);
        transform.position = new Vector3(8, randomYposition, 0);
    }
}
