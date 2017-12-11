using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour {
	public GameObject[] towns;
	public GameObject[] locks;

	public GameObject[] AderToPryShore;
	public GameObject[] AderToFairmount;
	public GameObject[] FairmountToTalgor;
	
	// Update is called once per frame
	void Start () {
		if (GameManager.Instance.DialogVariables["$q"].AsNumber >= 1) {
			towns [1].gameObject.GetComponent<BoxCollider> ().enabled = true;
			locks [0].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			if (!GameManager.Instance.AderToPryshore) {
				StartCoroutine (Path (AderToPryShore));
				GameManager.Instance.AderToPryshore = true;
			}
		}
		if (GameManager.Instance.DialogVariables["$q"].AsNumber >= 2) {
			towns [2].gameObject.GetComponent<BoxCollider> ().enabled = true;
			locks [1].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			if (!GameManager.Instance.AderToFairmount) {
				StartCoroutine (Path (AderToFairmount));
				GameManager.Instance.AderToFairmount = true;
			}
		}
		if (GameManager.Instance.DialogVariables["$q"].AsNumber >= 3) {
			towns [3].gameObject.GetComponent<BoxCollider> ().enabled = true;
			locks [2].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			if (!GameManager.Instance.FairmountToTalgor) {
				StartCoroutine (Path (FairmountToTalgor));
				GameManager.Instance.FairmountToTalgor = true;
			}
		}
		if (GameManager.Instance.DialogVariables["$glasses"].AsNumber == 3) {
			towns [4].gameObject.GetComponent<BoxCollider> ().enabled = true;
			locks [3].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene(GameManager.Instance.LastScene);
		}
	}

	IEnumerator Path(GameObject[] dots)
	{
		yield return new WaitForSeconds (0.5f);
		StartCoroutine(Dots(dots));
		yield return new WaitForSeconds (1.5f);
		StartCoroutine(removeDots(dots));
	}
	IEnumerator Dots(GameObject[] dots)
	{
		for (int i = 0; i < dots.Length; i++) {
			dots [i].SetActive(true);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine(Dots (dots));
	}
	IEnumerator removeDots(GameObject[] dots)
	{
		for (int i = 0; i < dots.Length; i++) {
			dots [i].SetActive(false);
			yield return new WaitForSeconds (0.5f);
		}
		StartCoroutine(removeDots (dots));
	}
}
