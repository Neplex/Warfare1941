using UnityEngine;

/*
Script for splash screen.
Load menu when any key was pressed
*/
public class splashScreen : MonoBehaviour {
	void Update () {
		if (Input.anyKey || Input.touchCount > 0) {
			SoundState.Instance.powerUp();
			GameState.Instance.loadMenu();
		}
	}
}
