using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkOnInvincibility : MonoBehaviour {

	public float speed = 4;

	private SpriteRenderer sprite;

	void Start () {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		var cl = sprite.color;

		if (GameState.Instance.isInvincible()) {
			cl.a = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f;
		} else {
			cl.a = 255;
		}

		sprite.color = cl;
	}
}
