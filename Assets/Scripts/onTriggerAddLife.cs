using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Add life to player when is trigger by player
*/
public class onTriggerAddLife : MonoBehaviour {

	public int lifeToAdd = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			GameState.Instance.addLifePlayer(lifeToAdd);
			SoundState.Instance.powerUp();
			Destroy(gameObject);
		}
	}
}
