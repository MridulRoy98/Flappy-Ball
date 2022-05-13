using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public int points;
 
    //Adding Rigidbody to ball and adding gravity
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.GetComponent<Rigidbody>().useGravity = true;
        
    }

    void Update()
    {

        //Adding constant downward force which keep the player falling
        rb.AddForce(Vector3.down * 1.5f);


        //Checking if there's a touch detected on screen
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                PlayerMovement();
            }

        }

        //flap mechanic for testing in PC
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerMovement();
        }

    }

    //Function for flap movement upward
    void PlayerMovement()
    {
        rb.velocity = Vector3.up * force;

    }


    //Checking if the player touches the pillars and if they do the game is restarted
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Obstacles" || collisionInfo.gameObject.name == "Obstacles_one" || collisionInfo.gameObject.name == "Obstacles_two" || collisionInfo.gameObject.name == "Floor")
        {
            RestartGame();
        }
        
    }


    //Checking if the player goes through the obstacles
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Detector" || other.gameObject.name == "Detector_one" || other.gameObject.name == "Detector_two")
        {
            //if the player crosses the detector between the pipes, they gain a point
            points += 1;
        }
    }

    //Restarts the game
    void RestartGame()
    {
        Debug.Log("You died");
        SceneManager.LoadScene(0);
    }

    //Returns the current points to show in UI script
    public int getPoints()
    {
        return points;
    }
}
