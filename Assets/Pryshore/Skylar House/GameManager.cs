using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject[] peices;
	public Text solved;

	private bool gameOver;
	// Update is called once per frame
	void Update () {
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
}
