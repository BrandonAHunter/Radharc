using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startPos;
	private GameObject[] peices;
	private GameObject[] missingStones;
	private BoxCollider[] movedColiders;
	void Start(){
		movedColiders = this.gameObject.GetComponents<BoxCollider> ();
		startPos = this.gameObject.transform.position;
		peices = new GameObject[18];
		for (int i = 0; i < peices.Length; i++) {
			peices [i] = GameObject.Find ("Peice " + (i+1));
		}
		missingStones = new GameObject[15];
		for (int i = 0; i < missingStones.Length; i++) {
			missingStones [i] = GameObject.Find ("Stone " + (i+1));
		}
	}

	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){
		
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		if (cursorPosition.x <= -3.3) {
			Vector3 scale = new Vector3 (0.5f, 0.5f, 1);
			this.transform.localScale = scale;
		} else {
			Vector3 scale = new Vector3 (1, 1, 1);
			this.transform.localScale = scale;
		}
		transform.position = cursorPosition;
	}

	void OnMouseUp(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		if (cursorPosition.x <= -4.2) {
			Vector3 scale = new Vector3 (0.5f, 0.5f, 1);
			this.transform.localScale = scale;
		}
		checkValidDrop ();
	}
	void checkValidDrop(){
		Debug.Log ("Hey");
		int numOfColissions = 0;
		Vector3 newPos = new Vector3(0,0,0);
		for (int i = 0; i < movedColiders.Length; i++) {
			for (int j = 0; j < missingStones.Length; j++) {
				if(movedColiders[i].bounds.Intersects(missingStones[j].GetComponent<BoxCollider>().bounds)){
					numOfColissions++;
					if (numOfColissions == 1)
						newPos = missingStones [j].gameObject.transform.position;
					Debug.Log ("A collider is valid");
					break;
				}
			}
		}
		if (numOfColissions == movedColiders.Length) {
			movedColiders [0].gameObject.transform.position = newPos;
			Debug.Log ("All Coliders are valid");
		}
		checkOverlap ();
	}
	void checkOverlap(){ 
		for (int i = 0; i < peices.Length; i++) {
			BoxCollider[] peicesColiders = peices [i].GetComponents<BoxCollider> ();
			for (int j = 0; j < movedColiders.Length; j++) {
				for (int k = 0; k < peicesColiders.Length; k++) {
					if (peices [i] == this.gameObject)
						continue;
					if (movedColiders [j].bounds.Intersects (peicesColiders [k].bounds)) {
						this.transform.position = startPos;
						Vector3 scale = new Vector3 (0.5f, 0.5f, 1);
						this.transform.localScale = scale;
						break;
					}
				}
			}
		}
	}
}
