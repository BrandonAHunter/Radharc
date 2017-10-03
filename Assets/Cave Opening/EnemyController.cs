using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 1.3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public Text score;
	public Text timer;
	public Text gameOver;
	public float scoreNum = 0;
	public bool GameOver;
	private float timeLeft = 30.0f;
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Update(){
		if (timeLeft > 0) {
			score.text = "score: " + scoreNum;
			timeLeft -= Time.deltaTime;
			timer.text = "" + timeLeft;
		} else {
			GameOver = true;
			timer.text = "0.00000";
			gameOver.text = "Game Over";
			CancelInvoke();
		}

	}


	void Spawn ()
	{
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
