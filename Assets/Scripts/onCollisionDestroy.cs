using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Destroy gameobject wen player hit it
*/
public class onCollisionDestroy : MonoBehaviour {

	public int life = 1; // The life of the game object (-1 by hit and destroy when life is 0)
	public int score = 50; // Score to add to player

	private ParticleSystem bulletSystem; // Particle system of player gun
	private ParticleSystem.Particle[] bullets; // Particles array
	private Collider2D hitBox; // Box collider of gameobject

	// Use this for initialization
	void Start () {
		GameObject playerGun = GameObject.FindGameObjectWithTag("playerGun");
		if (playerGun != null) bulletSystem = playerGun.GetComponent<ParticleSystem>();

		hitBox = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bulletSystem != null) checkCollisions();
	}

	private void checkCollisions() {
		// Update array
		bullets = new ParticleSystem.Particle[bulletSystem.particleCount];
		bulletSystem.GetParticles(bullets);

		// For all triggered particles if is in player hit box, hit the player
		for (int i = 0; i < bullets.Length; i++) {
			Vector2 particlePosition = bullets[i].position;

			// Particle are in 3D, set z to 0 to use Contains method
			Vector3 pos = new Vector3(particlePosition.x, particlePosition.y, 0);
			
			if (hitBox != null && hitBox.bounds.Contains(pos)) {
				bullets[i].remainingLifetime = 0;
				destroy();

				//SoundState.Instance.playerShot();
				Instantiate(
					Resources.Load("explosions/hit"),
					particlePosition,
					Quaternion.identity,
					transform
				);
			}
        }

		// Save array
		bulletSystem.SetParticles(bullets, bullets.Length);
	}

	private void destroy() {
		life--;

		if (life < 0) {
			GameState.Instance.addScorePlayer(score);
			GameState.Instance.addMultiplier();

			// Create an explosion
			SoundState.Instance.explosion();
			Instantiate(
				Resources.Load("explosions/expl_1"),
				transform.position,
				Quaternion.identity
			);

			onDestroySplit ds = GetComponent<onDestroySplit>();
			if (ds != null) ds.split();

			Destroy(gameObject);
		}
	}
}
