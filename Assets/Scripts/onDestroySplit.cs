using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Split an asteroid
*/
[RequireComponent(typeof(onCollisionDestroy))]
public class onDestroySplit : MonoBehaviour {

	public int nbAsteroid = 3; // Number of split part
	public float power = 2F; // Power of explosion

    public void split() {
        for (int i = 0; i < nbAsteroid; i++) newAsteroid();
    }

	private void newAsteroid() {
		// Instantiate the new gameobject
		GameObject gY = Instantiate(
			Resources.Load("foes/asteroidMed"),
			gameObject.transform.position,
			Quaternion.identity
		) as GameObject;

		// Apply random force to simulate explosion
		var rb = gY.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(
			rb.velocity.x + Random.Range(-power/4, power/4),
			rb.velocity.y - Random.Range(0, power)
		);
	}
}
