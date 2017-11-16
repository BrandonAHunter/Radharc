using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAi : MonoBehaviour {

	public float m_speed;
	public float m_period;
	public float m_degrees;
	public float m_amplitude;
	private bool dirRight = true;
	private Vector3 m_centerPosition;
	// Use this for initialization
	void Start() {
		m_centerPosition = transform.position;
		m_speed = 3.0f;
		m_period = 1.0f;
		m_amplitude = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;

		// Move center along x axis
		if(dirRight)
			m_centerPosition.x += deltaTime * m_speed;
		else
			m_centerPosition.x -= deltaTime * m_speed;

		if (m_centerPosition.x > 7.5f) {
			dirRight = false;
			this.gameObject.GetComponent<SpriteRenderer> ().flipX = true;
		} else if (m_centerPosition.x < -7.5f) {
			dirRight = true;
			this.gameObject.GetComponent<SpriteRenderer> ().flipX = false;
		}
		
		// Update degrees
		float degreesPerSecond = 360.0f / m_period;
		m_degrees = Mathf.Repeat(m_degrees + (deltaTime * degreesPerSecond), 360.0f);
		float radians = m_degrees * Mathf.Deg2Rad;

		// Offset by sin wave
		Vector3 offset = new Vector3(0.0f, m_amplitude * Mathf.Sin(radians), 0.0f);
		transform.position = m_centerPosition + offset;
	}
}
