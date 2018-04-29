using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour {

	public float amplitude = 1;
	public float speed = 0.5f;

	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
	}
	
	void Update () {
		transform.position = startPosition + new Vector3(0, Mathf.Sin(Time.time * speed) * amplitude, 0);
	}
}
