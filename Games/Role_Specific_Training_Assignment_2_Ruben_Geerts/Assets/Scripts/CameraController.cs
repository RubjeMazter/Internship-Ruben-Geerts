using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	// variables for this script
    public GameObject player;
    private Vector3 offset;

	// start with setting the offset
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame, but is always at the end of the frame
	// I used this because it works best with the camera and the player moving together
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
