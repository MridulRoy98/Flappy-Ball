using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    private int points = 0;
 


    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.GetComponent<Rigidbody>().useGravity = true;
        
    }

    void Update()
    {
        rb.AddForce(Vector3.down * 1.5f);

        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                PlayerMovement();
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerMovement();
        }

    }
    void PlayerMovement()
    {
        rb.velocity = Vector3.up * force;

    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Obstacles" || collisionInfo.gameObject.name == "Obstacles_one" || collisionInfo.gameObject.name == "Obstacles_two" || collisionInfo.gameObject.name == "Floor")
        {
            RestartGame();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Detector" || other.gameObject.name == "Detector_one" || other.gameObject.name == "Detector_two")
        {
            AddPoints();
        }
    }


    void RestartGame()
    {
        Debug.Log("You died");
        SceneManager.LoadScene(0);
    }

    void AddPoints()
    {
        points += 1;
        Debug.Log("Points: " + points);
    }
}
