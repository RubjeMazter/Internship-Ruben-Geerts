using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {
	// the quit button
	// if you are editting the game, quit button removes the game mode
	// if you are playing the game outside of unity, the game will close
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif 
    }
}
