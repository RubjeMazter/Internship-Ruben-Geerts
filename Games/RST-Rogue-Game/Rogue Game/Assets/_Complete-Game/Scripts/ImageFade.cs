using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImageFade : MonoBehaviour {
    public static Image levelImage;
	// Use this for initialization
	void Start () {
        levelImage = this.gameObject.GetComponent<Image>();
        FadeIn(0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void FadeIn(float time) {
        levelImage.CrossFadeAlpha(0, time, false);
    }

    public static void FadeOut(float time) {
        levelImage.gameObject.SetActive(true);
        levelImage.CrossFadeAlpha(0f, 0f, true); // needed to 
        levelImage.CrossFadeAlpha(1, time, true);
    }
}
