using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Increment fire rate of player when is trigger by player
*/
public class onTriggerAddSpeed : MonoBehaviour {

	public float speedMuliplier = 2F; // Speed multiplier
	public int bonusTime = 5; // Time of the multiplier

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			GameState.Instance.setShootRate(GameState.Instance.getShootRate() * speedMuliplier, bonusTime);
			SoundState.Instance.powerUp();
			Destroy(gameObject);
		}
	}
}
