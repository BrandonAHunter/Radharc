﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePiece : MonoBehaviour {
	public GameObject[] peices;
	public Text solved;

	private bool gameOver;
	private bool objectSelected = false;
	private GameObject[] rotatingObjects;
	void RotateObject() {
		Vector2 delta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * 40.0f;

		Vector3 mousePos = Input.mousePosition - screenCenter();
		Vector3 oldMousePos = new Vector3 (mousePos.x - delta.x, mousePos.y - delta.y, 0);

		float oldMouseAngle = Mathf.Atan2 (oldMousePos.y, oldMousePos.x) * (180 / Mathf.PI);
		float newMouseAngle = Mathf.Atan2 (mousePos.y, mousePos.x) * (180 / Mathf.PI);
		float angleDiff = newMouseAngle - oldMouseAngle;

		for (int i = 0; i < rotatingObjects.Length; i++) {
			rotatingObjects[i].transform.Rotate (0, 0, angleDiff);
		}
	}
	/*void OnMouseUp(){
		if ((transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 5) || (transform.eulerAngles.z >= 355 && transform.eulerAngles.z <= 360)) {
			this.gameObject.transform.rotation = Quaternion.identity;
		}
	}*/
	void Start(){
		for (int i = 0; i < peices.Length; i++) {
			peices[i].transform.localEulerAngles = new Vector3 (0, 0, Random.Range (30.0f, 330.0f));
		}
		rotatingObjects = new GameObject[0];
	}
	void Update(){
		if (Input.GetMouseButton (0)) {
			if (!objectSelected) {
				RaycastHit hit = new RaycastHit ();        
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag == "Object") {
						if (hit.collider.gameObject.name == "town1") {
							rotatingObjects = new GameObject[2];
							rotatingObjects [0] = GameObject.Find ("town1");
							rotatingObjects [1] = GameObject.Find ("town4");
						}
						else if (hit.collider.gameObject.name == "town2") {
							rotatingObjects = new GameObject[1];
							rotatingObjects [0] = GameObject.Find ("town2");
						}
						else if (hit.collider.gameObject.name == "town3") {
							rotatingObjects = new GameObject[2];
							rotatingObjects [0] = GameObject.Find ("town1");
							rotatingObjects [1] = GameObject.Find ("town3");
						}
						else if (hit.collider.gameObject.name == "town4") {
							rotatingObjects = new GameObject[2];
							rotatingObjects [0] = GameObject.Find ("town2");
							rotatingObjects [1] = GameObject.Find ("town4");
						}
					}
				}
				objectSelected = true;
			}
			else
				RotateObject ();

		}
		if (Input.GetMouseButtonUp (0)) {
			for (int i = 0; i < rotatingObjects.Length; i++) {
				if ((rotatingObjects[i].transform.eulerAngles.z >= 0 && rotatingObjects[i].transform.eulerAngles.z <= 5) || (rotatingObjects[i].transform.eulerAngles.z >= 355 && rotatingObjects[i].transform.eulerAngles.z <= 360)) {
					rotatingObjects[i].transform.rotation = Quaternion.identity;
				}
			}
			objectSelected = false;
			rotatingObjects = new GameObject[0];
		}
		for (int i = 0; i < peices.Length; i++) {
			if (peices [i].transform.localEulerAngles.z != 0) {
				gameOver = false;
				break;
			}
			gameOver = true;
		}
		if (gameOver) {
			solved.text = "You solved the Puzzle";
			for (int i = 0; i < peices.Length; i++) {
				peices [i].GetComponent<RotatePiece> ().enabled = false;
			}
		}
	}

	Vector3 screenCenter(){
		return new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0);
	}
}
