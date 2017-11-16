using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hookAI : MonoBehaviour {

	public GameObject[] objects;
	private float speed;
	private bool hooked;
	public Text wormText;
	private int worms;
	private GameObject hookedObject;
	// Use this for initialization
	void Start () {
		speed = 2.0f;
		worms = 5;
		hooked = false;
	}

	// Update is called once per frame
	void Update () {
		if (wormText != null) {
			wormText.text = worms.ToString ();
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up * speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (Vector2.down * speed * Time.deltaTime);
		} else if(this.transform.position.y < 8.5f){
			transform.Translate (Vector2.up * 0.25f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene("Pryshore");
		}
		if (this.gameObject.tag == "hook") {
			for (int i = 0; i < objects.Length; i++) {
				if (this.gameObject.GetComponent<BoxCollider> ().bounds.Intersects (objects [i].GetComponent<BoxCollider> ().bounds)) {
					if (!hooked) {
						hookedObject = objects [i];
						if (hookedObject.tag == "Object") {
							hookedObject.GetComponent<FishAi> ().enabled = false;
							hookedObject.GetComponent<hookAI> ().enabled = true;
							hooked = true;
						}
						else if (hookedObject.tag == "debri") {
							worms--;
							this.gameObject.transform.position = new Vector3 (0, 8.5f, 0);
						}
					;
					} else if(hooked && hookedObject != objects[i]){
						if (hookedObject.tag == "Object")
							hookedObject.GetComponent<FishAi> ().enabled = true;
						else if (hookedObject.tag == "debri")
							hookedObject.GetComponent<debriAI> ().enabled = true;
						
						hookedObject.GetComponent<hookAI> ().enabled = false;
						hooked = false;
						this.gameObject.transform.position = new Vector3 (0, 8.5f, 0);
						hookedObject = null;
					}
				}
			}
		}
		if (hookedObject != null && hookedObject.transform.position.y > 4) {
			Debug.Log ("You Win");
			GameManager.Instance.DialogVariables["$fish"] = new Yarn.Value(1);
			if(GameManager.Instance.DialogVariables ["$key"].AsNumber == 0)
				GameManager.Instance.DialogVariables["$key"] = new Yarn.Value(GameManager.Instance.DialogVariables ["$key"].AsNumber + 1);
			SceneManager.LoadScene("Pryshore");
		}
		if (worms <= 0) {
			Debug.Log ("You Lose");
			SceneManager.LoadScene("Pryshore");
		}
	}
}
