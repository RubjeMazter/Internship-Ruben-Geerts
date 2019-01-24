using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour {
	// variables for the spring joint
    public GameObject player;
    public JointSpring spring;
    public GameObject springRectangle;

	// if the player stays in the hitbox above the object inside the spring joint
	// and the player presses spacebar
	// the springjoint is broken, and the rectangle is destroyed
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player & Input.GetKeyDown("space"))
        {
            Destroy(springRectangle);
        }
    }
}
