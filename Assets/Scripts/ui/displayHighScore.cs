using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayHighScore : MonoBehaviour {
	void Update () {
		GetComponent<Text>().text = "" + GameState.Instance.getHighscore();
	}
}
