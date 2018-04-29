using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Sound state
*/
public class SoundState : MonoBehaviour {

	public static SoundState Instance = null; // Singleton instance

	// Music
	public AudioClip menuMusic;
	public AudioClip gameMusic;
	public AudioClip bossMusic;

	// Sound
	public AudioClip playerShotSound; // Sound when player shoot
	public AudioClip deathSound; // Sound when player loose a life
	public AudioClip explosionSound; // Explosion sound
	public AudioClip powerUpSound; // Sound when player pick up a bonus

	private AudioSource musicPlayer;

	void Start () {
		// Create singleton
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (Instance.gameObject);
		} else if (this != Instance) {
			Destroy (this.gameObject);
		}

		musicPlayer = GetComponent<AudioSource>();
	}

	/* Play music */
	private void PlayMusic(AudioClip newMusic) {
		musicPlayer.clip = newMusic;
    	musicPlayer.Play();
	}

	/* Play sound */
	private void MakeSound(AudioClip originalClip) {
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}

	public void startMenuMusic() {
		PlayMusic(menuMusic);
	}

	public void startGameMusic() {
		PlayMusic(gameMusic);
	}

	public void startBossMusic() {
		PlayMusic(bossMusic);
	}
	
	public void playerShot() {
		MakeSound(playerShotSound);
	}

	public void death() {
		MakeSound(deathSound);
	}

	public void explosion() {
		MakeSound(explosionSound);
	}

	public void powerUp() {
		MakeSound(powerUpSound);
	}
}
