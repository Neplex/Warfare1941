using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Enemies manager
*/
public class detectIfShips : MonoBehaviour {

	public uint nbEnemies = 4; // Number of enemies at the same time
	public float bossTime = 60; // Time in second between boss
	public string[] enemies = {"foes/Enemy1", "foes/Enemy2", "foes/Enemy3"}; // Enemy prefab list

	private Vector2 bottomLeftCameraBorder;
	private Vector2 topRightCameraBorder;
	private float timeLeftBeforeBoss;

	// Use this for initialization
	void Start () {
		bottomLeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, .2f));
		topRightCameraBorder   = Camera.main.ViewportToWorldPoint(new Vector2(1, .8f));
		timeLeftBeforeBoss = bossTime;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject boss = GameObject.FindGameObjectWithTag("boss");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

		// Create a boss if needed
		if (boss == null && timeLeftBeforeBoss <= 0) {
			newBoss();
			timeLeftBeforeBoss = bossTime;
		}

		// If no boss, just instantiate enemy
		if (boss == null && enemies.Length < nbEnemies) {
			if (Random.Range(1, 50) == 1 ||enemies.Length < 2) {
				newEnemy();
			}
		}

		if (boss == null) timeLeftBeforeBoss -= Time.deltaTime;
	}

	void newEnemy() {
		Vector2 newPosition = new Vector2(
			topRightCameraBorder.x,
			Random.Range(topRightCameraBorder.y, bottomLeftCameraBorder.y)
		);
		Quaternion rotation = Quaternion.Euler(0, 0, 90);

		Instantiate(
			Resources.Load(enemies[Random.Range(0, enemies.Length)]),
			newPosition,
			rotation,
			transform
		);
	}

	void newBoss() {
		Vector2 newPosition = new Vector2(topRightCameraBorder.x, 0);
		Quaternion rotation = Quaternion.Euler(0, 0, 90);

		Instantiate(
			Resources.Load("foes/Boss"),
			newPosition,
			rotation,
			transform
		);
	}
}
