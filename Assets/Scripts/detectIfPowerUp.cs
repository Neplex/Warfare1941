using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Power up manager
*/
public class detectIfPowerUp : MonoBehaviour {

	public int nbPowerUp = 1; // Number of power up at the same time
	public string[] powerUps = {"powerUpLife", "powerUpScore", "powerUpSpeed"}; // Power up prefab list

	private Vector2 bottomLeftCameraBorder;
	private Vector2 topRightCameraBorder;

	// Use this for initialization
	void Start () {
		bottomLeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		topRightCameraBorder   = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] powerUps = GameObject.FindGameObjectsWithTag("powerUp");
		if (powerUps.Length < nbPowerUp) {
			if (Random.Range(1, 100) == 1) {
				newPowerUp();
			}
		}
	}

	void newPowerUp() {
		Vector2 newPosition = new Vector2(
			topRightCameraBorder.x,
			Random.Range(topRightCameraBorder.y, bottomLeftCameraBorder.y)
		);

		Instantiate(
			Resources.Load(powerUps[Random.Range(0, powerUps.Length)]),
			newPosition,
			Quaternion.identity,
			transform
		);
	}
}
