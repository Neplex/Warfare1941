using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Kill yhe plaer when the gameobject hit it
*/
public class onCollisionKill : MonoBehaviour {

	private ParticleSystem bulletSystem; // Particle system for shooting enemies
	private ParticleSystem.Particle[] bullets; // Particles array
	private GameObject player;
	private Collider2D playerHitBox;

	// Use this for initialization
	void Start () {
		// Get particle system
		bulletSystem = GetComponent<ParticleSystem>();
		if (bulletSystem != null)  bullets = new ParticleSystem.Particle[bulletSystem.main.maxParticles];

		// Get player box collider
		player = GameObject.FindGameObjectWithTag("Player");
		if (player != null) playerHitBox = player.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bulletSystem != null) checkCollisions();
	}

	// Object detection
	void OnTriggerEnter2D(Collider2D other) {
		killPlayer(other.gameObject);
	}

	// Particles detection
	private void checkCollisions() {
		bulletSystem.GetParticles(bullets);

		// For all triggered particles if is in player hit box, hit the player
		for (int i = 0; i < bullets.Length; i++) {
            Vector3 particlePosition = bullets[i].position;

			// Particle are in 3D, set z to 0 to use Contains method
			Vector3 pos = new Vector3(particlePosition.x, particlePosition.y, 0);
			
			if (playerHitBox != null && playerHitBox.bounds.Contains(pos)) {
				killPlayer(player);
				break; // Just take one damage
			}
        }
	}

	// Kill a player candidat. If is not the player, nothing append.
	private void killPlayer(GameObject go) {
		if (go.tag == "Player") {
			SoundState.Instance.death();
			GameState.Instance.removeLifePlayer();
			GameState.Instance.resetMultiplier();
			// need invinsibility for 2 second
			if (GameState.Instance.getLifePLayer() == 0) {
				Destroy(go);
				SceneManager.LoadScene("03_GameOver");
			}
		}
	}
}
