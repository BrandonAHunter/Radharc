using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalgorManager : MonoBehaviour {
	public GameObject noWheel;
	public GameObject withWheel;

	void Update () {
		if (GameManager.Instance.DialogVariables ["$wheelLgGet"].AsBool) {
			noWheel.SetActive (false);
			withWheel.SetActive (true);
		}
	}
}
