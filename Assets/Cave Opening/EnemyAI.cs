using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float speed;
	private bool dirRight = true;

	void OnMouseDown()
	{
		GameObject.Find("GameRoot").GetComponent<EnemyController>().scoreNum++;
		Debug.Log ("Killed");
		Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start() {
		speed = Random.Range (6.0f, 8.0f);
		if (transform.position.x == -12) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			dirRight = true;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			dirRight = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameObject.Find ("GameRoot").GetComponent<EnemyController> ().GameOver) {
			if (dirRight)
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			else
				transform.Translate (-Vector2.right * speed * Time.deltaTime);

			if (transform.position.x > 12.0f) {
				Destroy (this.gameObject);
			}

			if (transform.position.x < -12.0f) {
				Destroy (this.gameObject);
			}
		}
	}
}
