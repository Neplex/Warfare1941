using UnityEngine;

/*
Controller for menu button
*/
public class clickButtonPlay : MonoBehaviour {
	public void onClick() {
		GameState.Instance.startEndlessGame();
	}
}
