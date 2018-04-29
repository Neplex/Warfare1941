using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Move asteroid and power up
*/
public class moveAsteroid : MonoBehaviour {

	public Vector2 speed = new Vector2(-5F, 1F); // Mean speed for x and y axes
	public float angularSpeed = 20F; // Mean angular speed

	private Vector2 size;
	private Vector2 bottomLeftCameraBorder;
	private Vector2 topRightCameraBorder;

    // Use this for initialization
    void Start () {
		size = GetComponent<SpriteRenderer>().bounds.extents;
		bottomLeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		topRightCameraBorder   = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// Init speeds
		speed.x = Random.Range(speed.x/2, speed.x*2);
		speed.y = Random.Range(-speed.y, speed.y);
		angularSpeed = Random.Range(angularSpeed/2, angularSpeed*2);

		GetComponent<Rigidbody2D>().velocity = speed;
	}
	
	// Update is called once per frame	
	void Update () {
		GetComponent<Rigidbody2D>().angularVelocity = angularSpeed;

		// Destroy the gameobject if it is outside the screen
		if ((transform.position.x + size.x) < bottomLeftCameraBorder.x ||
			(transform.position.y + size.y) < bottomLeftCameraBorder.y ||
			(transform.position.y - size.y) > topRightCameraBorder.y) {
			Destroy(gameObject);
		}
	}

	private void OnDestroy() {
		// Debug.Log("DESTROY");
	}
}
