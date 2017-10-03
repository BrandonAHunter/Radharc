using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAi : MonoBehaviour {

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
	}

	// Update is called once per frame
	void Update () {
		if (dirRight)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		else
			transform.Translate (-Vector2.right * speed * Time.deltaTime);

		if(transform.position.x > 9.0f) {
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			dirRight = false;
		}

		if(transform.position.x < -2.5f) {
			dirRight = true;
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
		}
	}
}
