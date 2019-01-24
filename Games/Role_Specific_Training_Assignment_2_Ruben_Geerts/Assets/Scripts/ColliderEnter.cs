using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnter : MonoBehaviour {

	// variables for this script
	// player, the "elevator" itself and the rigidbody
    public GameObject player;
    public GameObject elevator;
    public Rigidbody m_Rigidbody;

	// I froze the "elevator" in unity, and unfreeze it by code when the player presses space
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player & Input.GetKeyDown("space"))
        {
            m_Rigidbody.constraints = RigidbodyConstraints.None;
        }
        
    }
}
