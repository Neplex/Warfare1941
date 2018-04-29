using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Player shoot manager
*/
public class shootAgain : MonoBehaviour {
	
	private ParticleSystem ps;
	private bool isShooting = false;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		var emission = ps.emission;

		// Update shoot rate
        emission.rateOverTime = GameState.Instance.getShootRate();

		// Stop or start emetting particles
		bool nexState = Input.GetButton("Fire1");

		if (!isShooting && nexState) ps.Play();
		if (isShooting && !nexState) ps.Stop();

		isShooting = nexState;
	}
}
