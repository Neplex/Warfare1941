using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Blinck a text ui
*/
public class blinkText : MonoBehaviour {

	public float speed = 2;
	
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		var cl = text.color;
		cl.a = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f;
		text.color = cl;
	}
}
