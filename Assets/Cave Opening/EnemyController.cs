using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class EnemyController : MonoBehaviour {
	public GameObject enemy;
	public Transform[] spawnPoints;

	public bool Killable = true;
	public bool GameOver = false;
	public float numOfBats = 0;

	private float spawnTime = 1.3f;
	private float timeLeft = 45.0f;
	void Start ()
	{
		spawnTime = 0.7f;
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Update(){
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
		} else if(! GameOver){
			Debug.Log("you win");
			GameOver = true;
			Killable = false;
			CancelInvoke();
			FindObjectOfType<DialogueRunner> ().StartDialogue ("Cave.Win");
		}

		if(numOfBats == 15 && Killable){
			Debug.Log ("you loss");
			Killable = false;
			FindObjectOfType<DialogueRunner> ().StartDialogue ("Cave.Lose");
		}

		if(numOfBats == 30){
			CancelInvoke();
		}
	}

	void Spawn ()
	{
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

		numOfBats++;
	}
}
