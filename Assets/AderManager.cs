using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AderManager : MonoBehaviour {

	public GameObject Letter;
	public GameObject aderKyran;
	public GameObject aderNoWheel;
	public GameObject kyran;

	void Start(){
		if (! GameManager.Instance.Letter) {
			GameManager.Instance.Letter = true;
			Letter.SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.DialogVariables ["$kyran"].AsBool) {
			aderKyran.SetActive (true);
			kyran.SetActive (true);
		}
		if (GameManager.Instance.DialogVariables ["$wheelsm"].AsBool) {
			aderNoWheel.SetActive (true);
		}
	}
}
