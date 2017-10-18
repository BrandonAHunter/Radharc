using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hookAI : MonoBehaviour {

	public GameObject[] objects;
	private float speed;
	private bool hooked;
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
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector2.up * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate (Vector2.down * speed * Time.deltaTime);
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
							this.gameObject.transform.position = new Vector3 (0, 3.5f, -2);
						}
					;
					} else if(hooked && hookedObject != objects[i]){
						if (hookedObject.tag == "Object")
							hookedObject.GetComponent<FishAi> ().enabled = true;
						else if (hookedObject.tag == "debri")
							hookedObject.GetComponent<debriAI> ().enabled = true;
						
						hookedObject.GetComponent<hookAI> ().enabled = false;
						hooked = false;
						this.gameObject.transform.position = new Vector3 (0, 3.5f, -2);
						hookedObject = null;
					}
				}
			}
		}
		if (hookedObject != null && hookedObject.transform.position.y > 3.5) {
			Debug.Log ("You Win");
			GameManager.Instance.Fish = true;
			GameManager.Instance.Progress++;
			SceneManager.LoadScene("Pryshore");
		}
	}
}
