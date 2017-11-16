using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RotatePiece : MonoBehaviour {
	public GameObject[] peices;
	public Text solved;

	private bool gameOver;
	private bool objectSelected = false;
	private GameObject[] rotatingObjects;
	private float userForgiveness;
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
		userForgiveness = 3.0f;
	}
	void Update(){
		if (Input.GetMouseButton (0)) {
			if (!objectSelected) {
				RaycastHit hit = new RaycastHit ();        
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag == "Object") {
						if (hit.collider.gameObject.name == "bird1") {
							rotatingObjects = new GameObject[2];
							rotatingObjects [0] = GameObject.Find ("bird1");
							rotatingObjects [1] = GameObject.Find ("bird4");
						}
						else if (hit.collider.gameObject.name == "bird2") {
							rotatingObjects = new GameObject[1];
							rotatingObjects [0] = GameObject.Find ("bird2");
						}
						else if (hit.collider.gameObject.name == "bird3") {
							rotatingObjects = new GameObject[2];
							rotatingObjects [0] = GameObject.Find ("bird1");
							rotatingObjects [1] = GameObject.Find ("bird3");
						}
						else if (hit.collider.gameObject.name == "bird4") {
							rotatingObjects = new GameObject[2];
							rotatingObjects [0] = GameObject.Find ("bird2");
							rotatingObjects [1] = GameObject.Find ("bird4");
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
				if ((rotatingObjects[i].transform.eulerAngles.z >= 0 && rotatingObjects[i].transform.eulerAngles.z <= userForgiveness) || (rotatingObjects[i].transform.eulerAngles.z >= 360 - userForgiveness && rotatingObjects[i].transform.eulerAngles.z <= 360)) {
					rotatingObjects[i].transform.rotation = Quaternion.identity;
				}
			}
			objectSelected = false;
			rotatingObjects = new GameObject[0];
		}
		float zAngle = Mathf.Floor(peices [0].transform.localEulerAngles.z);
		for (int i = 1; i < peices.Length; i++) {
			if (peices [i].transform.localEulerAngles.z > zAngle + userForgiveness || peices [i].transform.localEulerAngles.z < zAngle - userForgiveness) {
				gameOver = false;
				break;
			}
			gameOver = true;
		}
		if (gameOver) {
			GameManager.Instance.DialogVariables ["$glasses"] = new Yarn.Value (GameManager.Instance.DialogVariables ["$glasses"].AsNumber + 1);
			GameManager.Instance.DialogVariables ["$box"] = new Yarn.Value (false);
			SceneManager.LoadScene ("Locations/" + GameManager.Instance.LastScene);
		}
	}

	Vector3 screenCenter(){
		return new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0);
	}
}
