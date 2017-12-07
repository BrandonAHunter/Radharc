using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameManager.Instance.DialogVariables ["$wheelLgGet"].AsBool) {
			this.gameObject.SetActive (false);
		}
	}
}
