using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Move enemies
*/
public class moveEnemyShip : MonoBehaviour {

	public float speed = -5.0F; // Mean speed

	private Vector2 bottomLeftCameraBorder;
	//private Vector2 topRightCameraBorder;

	// Use this for initialization
	void Start () {
		// Random stop x position
		float pos = Random.Range(.6F, .8F);

		bottomLeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(pos, 0));
		//topRightCameraBorder   = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// Init speed
		speed = Random.Range(speed/2, speed*2);
	}
	
	// Update is called once per frame
	void Update () {
		// Move the enemy as long as he is not in the correct position
		if (transform.position.x > bottomLeftCameraBorder.x) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
		} else {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		}
	}
}
