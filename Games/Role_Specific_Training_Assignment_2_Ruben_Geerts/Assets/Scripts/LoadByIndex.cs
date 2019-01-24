using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadByIndex : MonoBehaviour
{
	// load the scene with the number put in in Unity (1)
    public void LoadThroughIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
