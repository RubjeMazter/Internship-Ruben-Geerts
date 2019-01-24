using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    // variables
    public Transform ground;
    public Transform obstacle;
    public PlayerMovement player;
    public Transform coin;


    void Start()
    {
        // Create 1000 floors 10 units apart
        for (int i = 0; i < 2000; i++)
        {
            Instantiate(ground, new Vector3(0.0f, -1.53f, i * 10.0f), Quaternion.Euler(90.0f, 0.0f, 0.0f));
        }

        GameObject plane = GameObject.Find("Plane");
        LevelGeneration playerScript = player.GetComponent<LevelGeneration>();


    }
    void Update()
    {
        // more variables, randomizing numbers, for future use
        int ObstacleLocation = Random.Range(1, 4);
        int CoinDropRate = Random.Range(1, 300);
        int CoinLane = Random.Range(1, 4);
        int CoinHeight = Random.Range(1, 3);
        float ObjectPlacement = player.transform.position.z + 150;

        // if the randomised number is 1 an obstacle will be placed
        int ObjectSelect = Random.Range(1, 50);

        // if the player speed is between 25 and 35, the object placing rate is increased
        if (player.speed > 25 && player.speed < 35)
        {
            ObjectSelect = Random.Range(1, 30);
        } 

        // if the player speed is between 35 and 45 the object placing rate is increased even more
        if (player.speed > 35 && player.speed < 45)
        {
            ObjectSelect = Random.Range(1, 18);
        }
       
        // if the player speed is higher than 45, object placing rate is increased
        if (player.speed > 45)
        {
            ObjectSelect = Random.Range(1, 10);
        }
        if (ObjectSelect == 1)
        {
            // if the ObstacleLocation is 1, obstacle will be put in the right lane
            if (ObstacleLocation == 1)
            {
                Instantiate(obstacle, new Vector3(5, 0, ObjectPlacement), Quaternion.identity);
            }
            // if the ObstacleLocation is 2, obstacle will be put in the middle lane
            if (ObstacleLocation == 2)
            {
                Instantiate(obstacle, new Vector3(0, 0, ObjectPlacement), Quaternion.identity);
            }
            // if the ObstacleLocation is 3, obstacle will be put in the left lane
            if (ObstacleLocation == 3)
            {
                Instantiate(obstacle, new Vector3(-5, 0, ObjectPlacement), Quaternion.identity);
            }
        }
        // The same principle goes for the coins, but if coinheight is 1, the coin will be placed on the floor, otherwise the coin is placed in the air
        if (CoinDropRate == 1)
        {
            // if the coinlane is 1, place the coin in the right lane
            if (CoinLane == 1)
            {
                // if the coinheight is 1, place the coin on the floor, otherwise place it in the air
                if (CoinHeight == 1)
                {
                    Instantiate(coin, new Vector3(5, 0, ObjectPlacement), Quaternion.identity);
                }
                else
                {
                    Instantiate(coin, new Vector3(5, 5, ObjectPlacement), Quaternion.identity);
                }
            }
            // if the coinlane is 2, place the coin in the middle lane
            if(CoinLane == 2)
            { 
                if (CoinHeight == 1)
                {
                    Instantiate(coin, new Vector3(0, 0, ObjectPlacement), Quaternion.identity);
                }
                else
                {
                    Instantiate(coin, new Vector3(0, 5, ObjectPlacement), Quaternion.identity);
                }
            
            }
            else
            {
                // if the coinlane is something else (3), place the coin in the right lane
                if (CoinHeight == 1)
                {
                    Instantiate(coin, new Vector3(-5, 0, ObjectPlacement), Quaternion.identity);
                }
                else
                {
                    Instantiate(coin, new Vector3(-5, 5, ObjectPlacement), Quaternion.identity);
                }
            }
        }
    }
}
