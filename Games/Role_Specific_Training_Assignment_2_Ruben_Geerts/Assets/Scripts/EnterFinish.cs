using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFinish : MonoBehaviour {
	// variables for the finish, the sound to play, and the audiosource
	public GameObject finish;
	public AudioClip finishSound;
	private AudioSource source;

	// on awake of the game, get the audiosource
	void Awake()
	{
		source = GetComponent<AudioSource> ();
	}

	// when the player enters the hitbox above the finish
	// check if the hitbox has the tag finish
	// if this is true, play the finishsound
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("finish")) {
			source.PlayOneShot (finishSound, 1F);
		}
	}
}
