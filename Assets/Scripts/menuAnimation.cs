using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAnimation : MonoBehaviour {

	public bool fromRight = false;

	private Vector2 finalPosition;

	void Start () {
		// Save the current position as the final
		finalPosition = transform.position;

		Vector2 bottomLeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 topRightCameraBorder   = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		Vector2 size = GetComponent<SpriteRenderer>().bounds.extents;
		Vector2 pos  = new Vector2(0, transform.position.y);

		// Compute x position outside the screen
		pos.x = fromRight ? topRightCameraBorder.x + size.x : bottomLeftCameraBorder.x - size.x;

		// Set the position
		transform.position = pos;
	}
	
	void Update () {
		// Smooth movement to the final position
		transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * 2);
	}
}
