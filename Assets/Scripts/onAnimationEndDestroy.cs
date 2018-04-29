using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Destroy a gameobject at the end of its animation
*/
public class onAnimationEndDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Destroy with a delay: animation duration
		Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
