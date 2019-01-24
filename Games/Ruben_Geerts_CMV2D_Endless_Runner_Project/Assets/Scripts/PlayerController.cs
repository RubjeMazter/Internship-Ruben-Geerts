using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // variables for the sound
    public GameObject coin;
    public AudioClip pickUpSound;

    private AudioSource source;

    void Awake()
    {
        // get the audiosource that is in the scene
        source = GetComponent<AudioSource>();
    }

    // if the player collides with an object with the tag "Coin", delete the object, and play a sound
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            source.PlayOneShot(pickUpSound, 1F);
        }
    }
}
