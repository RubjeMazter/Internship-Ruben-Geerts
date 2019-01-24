using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // variables
    public GameObject player;
    public float speed = 15.0f;
    public bool grounded = true;
    public float ypos = 0;
    public float yspeed = 0;

    // Update is called once per frame
    void Update()
    {
        // speed and direction variables
        Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 oldPosition = transform.position;
        Vector3 speedVector = direction * speed;
        Vector3 newPosition = oldPosition + speedVector * Time.deltaTime;
        transform.position = newPosition;
        speed = speed * 1.0003f;

        if (Time.timeScale != 0)
        {
            // if the player presses the left arrow key, the player will be moved 0.11 units to the left every frame
            if (Input.GetKey("left"))
            {
                if (newPosition.x > -5)
                {
                    transform.Translate(-0.11f, 0.0f, 0.0f);
                }
            }
            // if the player presses the left arrow key, the player will be moved 0.11 units to the right every frame
            if (Input.GetKey("right"))
            {
                if (newPosition.x < 5)
                {
                    transform.Translate(0.11f, 0.0f, 0.0f);
                }
            }
            // if the player presses the up arrow key, the player will have a yspeed
            if (ypos == 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    yspeed = 25;
                }
            }
            // this yspeed formula then is used to create a parabola shaped jump            
            yspeed = yspeed - (50 * Time.deltaTime);
            ypos = ypos + (yspeed * Time.deltaTime);
            if (ypos < 0.0f)
            {
                ypos = 0.0f;
                yspeed = 0.0f;
            }
            transform.position = new Vector3(transform.position.x, ypos, transform.position.z);
        }
    }

    // if the player collides with an object with the tag Öbstacle, the player will be destroyed, and the replay scene will be loaded
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0;
            StartGameOnClick startGame = GameObject.FindObjectOfType<StartGameOnClick>();
            startGame.LoadByIndex(2);
            
            Destroy(player);
        }
    }
}
