using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Game state
*/
public class GameState : MonoBehaviour {

	public static GameState Instance = null; // Singleton instance
	public int initLifePlayer = 3; // Starting life for player
	public float initShootRate = 1f; // Default shoot rate
	public float invincibility = 2f; // Invincibility time after death

	private int scorePlayer; // Player score
	private int lifePlayer; // Player current life
	private float shootRate; // Player current shoot rate
	private float shootRateTime; // Time left for shoot rate power-up
	private float invincibilityTime; // Time left for invincibility
	private int multiplier; // Current score multiplier

	public void reset() {
		lifePlayer = initLifePlayer;
		shootRate = initShootRate;
		scorePlayer = 0;
		shootRateTime = 0;
		invincibilityTime = 0;
		resetMultiplier();
	}

	// Use this for initialization
	void Start () {
		// Create singleton
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (Instance.gameObject);
		} else if (this != Instance) {
			Destroy (this.gameObject);
		}

		// Init
		reset();
	}
	
	// Update is called once per frame
	void Update () {
		// Reset shoot rate when the time is over
		if (shootRateTime <= 0) {
			shootRate = initShootRate;
		} else {
			shootRateTime -= Time.deltaTime;
		}

		// Reduce invincibility time
		if (isInvincible()) {
			invincibilityTime -= Time.deltaTime;
		}

		updateHighscore(scorePlayer);
	}

	public void loadMenu() {
		SceneManager.LoadScene("01_Menu");
		SoundState.Instance.startMenuMusic();
	}

	public void startEndlessGame() {
		SceneManager.LoadScene("02_Game");
		SoundState.Instance.startGameMusic();
		reset();
	}

	public void addScorePlayer(int toAdd) {
		scorePlayer += toAdd * multiplier;
	}

	public int getScorePlayer() {
		return scorePlayer;
	}

	public void addLifePlayer(int toAdd = 1) {
		lifePlayer += toAdd;
	}

	public void removeLifePlayer(int toRemove = 1) {
		// Remove life if is not invincible
		if (!isInvincible()) {
			setInvincible();
			lifePlayer -= toRemove;
		}
	}

	public int getLifePLayer() {
		return lifePlayer;
	}

	public float getShootRate() {
		return shootRate;
	}

	public void setShootRate(float Rate, int time) {
		shootRate = Rate;
		shootRateTime += time;
	}

	public int getMultiplier() {
		return multiplier;
	}

	public void addMultiplier(int m = 1) {
		multiplier += m;
	}

	public void resetMultiplier() {
		multiplier = 1;
	}

	private void updateHighscore(int score) {
		if (score > getHighscore()) {
			PlayerPrefs.SetInt("highScore", score);
		}
	}

	public int getHighscore() {
		return PlayerPrefs.GetInt("highScore", 0);
	}

	private void setInvincible() {
		invincibilityTime = invincibility;
	}

	public bool isInvincible() {
		return invincibilityTime > 0;
	}
}
