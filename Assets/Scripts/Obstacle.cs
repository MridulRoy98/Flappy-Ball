using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 tempPosition;

    // Update is called once per frame
    void Update()
    {
        tempPosition = transform.position;
        tempPosition.x -= 0.01f;
        transform.position = tempPosition;

        if (transform.position.x <= -4)
        {
            RecycleObject();
        }

    }
    void RecycleObject()
    {
        float randomYposition = Random.Range(-2.5f, 2.5f);
        transform.position = new Vector3(8, randomYposition, 0);
    }
}
