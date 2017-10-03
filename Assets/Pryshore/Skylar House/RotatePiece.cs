using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePiece : MonoBehaviour {

	void OnMouseDrag() {
		Vector2 delta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * 40.0f;

		Vector3 mousePos = Input.mousePosition - screenCenter();
		Vector3 oldMousePos = new Vector3 (mousePos.x - delta.x, mousePos.y - delta.y, 0);

		float oldMouseAngle = Mathf.Atan2 (oldMousePos.y, oldMousePos.x) * (180 / Mathf.PI);
		float newMouseAngle = Mathf.Atan2 (mousePos.y, mousePos.x) * (180 / Mathf.PI);
		float angleDiff = newMouseAngle - oldMouseAngle;

		this.gameObject.transform.Rotate (0, 0, angleDiff);
	}
	void OnMouseUp(){
		if ((transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 5) || (transform.eulerAngles.z >= 355 && transform.eulerAngles.z <= 360)) {
			this.gameObject.transform.rotation = Quaternion.identity;
		}
	}
	void Start(){
		transform.localEulerAngles = new Vector3 (0, 0, Random.Range (30.0f,330.0f));
	}
	Vector3 screenCenter(){
		return new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0);
	}
}
