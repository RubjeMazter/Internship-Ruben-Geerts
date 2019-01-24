using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueSetter : MonoBehaviour {

    public static float maximum = 100;
    public static float currentValue;
    
    Slider slider;
	// Use this for initialization
	void Start () {
        slider = this.gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        slider.maxValue = maximum;

        slider.value = currentValue;
	}
}
