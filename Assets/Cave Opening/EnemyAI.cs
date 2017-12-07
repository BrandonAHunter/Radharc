using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private float m_speed;
	private float m_period;
	private float m_degrees;
	private float m_amplitude;
	private bool dirRight = true;
	private Vector3 m_centerPosition;
	private EnemyController gameRoot;
	private AudioSource HitBat;

	void OnMouseDown()
	{
		if (gameRoot.Killable) {
			gameRoot.numOfBats--;
			Debug.Log ("Killed");
			HitBat.Play();
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start() {
		gameRoot = GameObject.Find ("GameRoot").GetComponent<EnemyController> ();
		HitBat = GameObject.Find ("Audio Source_bat").GetComponent<AudioSource>();
		m_centerPosition = transform.position;
		m_speed = 8.0f;
		m_period = 2.0f;
		m_amplitude = 0.5f;
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
		if (! gameRoot.GameOver) {
			// Move center along x axis
			if (dirRight)
				m_centerPosition.x += Time.deltaTime * m_speed;
			else
				m_centerPosition.x -= Time.deltaTime * m_speed;

			if (m_centerPosition.x > 7.5f) {
				dirRight = false;
				this.gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			} else if (m_centerPosition.x < -7.5f) {
				dirRight = true;
				this.gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			}

			// Update degrees
			float degreesPerSecond = 360.0f / m_period;
			m_degrees = Mathf.Repeat (m_degrees + (Time.deltaTime * degreesPerSecond), 360.0f);
			float radians = m_degrees * Mathf.Deg2Rad;

			// Offset by sin wave
			Vector3 offset = new Vector3 (0.0f, m_amplitude * Mathf.Sin (radians), 0.0f);
			transform.position = m_centerPosition + offset;
		} else{
			if (dirRight)
				m_centerPosition.x += Time.deltaTime * m_speed;
			else
				m_centerPosition.x -= Time.deltaTime * m_speed;
			// Update degrees
			float degreesPerSecond = 360.0f / m_period;
			m_degrees = Mathf.Repeat (m_degrees + (Time.deltaTime * degreesPerSecond), 360.0f);
			float radians = m_degrees * Mathf.Deg2Rad;

			// Offset by sin wave
			Vector3 offset = new Vector3 (0.0f, m_amplitude * Mathf.Sin (radians), 0.0f);
			transform.position = m_centerPosition + offset;
		}
	}
}
