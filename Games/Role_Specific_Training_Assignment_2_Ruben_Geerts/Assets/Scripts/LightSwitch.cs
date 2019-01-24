using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {
	// variables for the lighting

    public GameObject player;
    public Light Switch1;
    public Light Switch2;
    public Light Switch3;
    public Light Switch4;
    public Light Switch5;
    public Light Switch6;

	// if the player stays in the hitbox
	// and presses space in the hitbox
	// enable or disable the lights (depending on the state they are in now)
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player & Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("spacebar!");
            Switch1.enabled = !Switch1.enabled;
            Switch2.enabled = !Switch2.enabled;
            Switch3.enabled = !Switch3.enabled;
            Switch4.enabled = !Switch4.enabled;
            Switch5.enabled = !Switch5.enabled;
            Switch6.enabled = !Switch6.enabled;
        }
            
    }
}
