using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public static GameObject cam;
    public static GameObject hurtImage;
    public GameObject image;

    public void Start() {
        cam = this.gameObject;

        hurtImage = GameObject.Find("HurtImage");
        hurtImage.gameObject.SetActive(false);

    }

    public static IEnumerator Shake( float duration, float strenght) {
        Vector3 originalPos = cam.transform.position;

        float timePassed = 0f;

        while (timePassed < duration) {
            hurtImage.gameObject.SetActive(true);
            float randomX = Random.Range(originalPos.x -strenght, originalPos.x +strenght);
            float randomY = Random.Range(originalPos.y -strenght, originalPos.y +strenght);

            cam.transform.position = new Vector3(randomX, randomY, originalPos.z);
            timePassed += Time.deltaTime;
            yield return null;
        }
        hurtImage.gameObject.SetActive(false);

        cam.transform.position = originalPos;
    }
}
