using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollider : MonoBehaviour
{
	// variables for the first interactive obstacle
    public GameObject player;
    public GameObject block;

	// when the object collides with the hitbox above the obstacle, and presses space, remove the obstacle.
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player & Input.GetKeyDown("space"))
        {
            Destroy(block);
        }
    }
}
