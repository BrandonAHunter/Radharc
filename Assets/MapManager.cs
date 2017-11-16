using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour {
	public GameObject[] towns;
	public GameObject[] locks;
	
	// Update is called once per frame
	void Start () {
		if (GameManager.Instance.DialogVariables["$q"].AsNumber >= 1) {
			towns [1].gameObject.GetComponent<BoxCollider> ().enabled = true;
			locks [0].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (GameManager.Instance.DialogVariables["$q"].AsNumber >= 2) {
			towns [2].gameObject.GetComponent<BoxCollider> ().enabled = true;
			locks [1].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (GameManager.Instance.DialogVariables["$q"].AsNumber >= 3) {
			towns [3].gameObject.GetComponent<BoxCollider> ().enabled = true;
			locks [2].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene(GameManager.Instance.LastScene);
		}
	}
}
