using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debriAI : MonoBehaviour {

	private float speed;
	private bool dirRight = true;

	// Use this for initialization
	void Start() {
		speed = 2.0f;
	}

	// Update is called once per frame
	void Update () {
		if (dirRight)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		else
			transform.Translate (-Vector2.right * speed * Time.deltaTime);

		if(transform.position.x > 4.0f) {
			dirRight = false;
		}

		if(transform.position.x < -4.0f) {
			dirRight = true;
		}
	}
}
