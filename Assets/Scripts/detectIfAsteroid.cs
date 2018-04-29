using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Asteroid manager
*/
public class detectIfAsteroid : MonoBehaviour {

	public int nbAsteroid = 10; // Number of asteroid at the same time

	private Vector2 bottomLeftCameraBorder;
	private Vector2 topRightCameraBorder;

	// Use this for initialization
	void Start () {
		bottomLeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		topRightCameraBorder   = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag("asteroid");
		if (asteroids.Length < nbAsteroid) {
			if (Random.Range(1, 50) == 1 || asteroids.Length < 4) {
				newAsteroid();
			}
		}
	}

	void newAsteroid() {
		Vector2 newPosition = new Vector2(
			topRightCameraBorder.x,
			Random.Range(topRightCameraBorder.y, bottomLeftCameraBorder.y)
		);

		Instantiate(
			Resources.Load("foes/asteroidBig"),
			newPosition,
			Quaternion.identity,
			transform
		);
	}
}
