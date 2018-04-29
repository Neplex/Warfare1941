using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Move player
*/
public class moveShip : MonoBehaviour {
	public Vector2 speed = new Vector2(5.0F, 5.0F); // Speed of the player

	private Vector2 bottomLeftCameraBorder;
	private Vector2 topRightCameraBorder;

	// Use this for initialization
	void Start () {
		bottomLeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		topRightCameraBorder   = Camera.main.ViewportToWorldPoint(new Vector2(.5F, 1));
	}

	/* Get a position in the range min/max */
	float computePosition(float pos, float size, float min, float max) {
		if ((pos - size) < min) {
			pos = min + size;
		} else if ((pos + size) > max) {
			pos = max - size;
		}

		return pos;
	}

	/* Keep the player in the screen */
	void computePositions() {
		Vector2 pos = transform.position;
		Vector2 size = GetComponent<SpriteRenderer>().bounds.extents;

		transform.position = new Vector2(
			computePosition(pos.x, size.x, bottomLeftCameraBorder.x, topRightCameraBorder.x),
			computePosition(pos.y, size.y, bottomLeftCameraBorder.y, topRightCameraBorder.y)
		);
	}
	
	// Update is called once per frame
	void Update () {
		// Get direction from keyboard and joystick
		Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		// If touch enable, get the direction vector between player position and touch position
		if (Input.touchCount > 0) {
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			direction = touchPosition - transform.position;
		}
		
		// Apply a velocity to player, direction by speed
		GetComponent<Rigidbody2D>().velocity = new Vector2(
			direction.x * speed.x,
			direction.y * speed.y
		);

		computePositions(); // Keep the player in screen bounds
	}
}
