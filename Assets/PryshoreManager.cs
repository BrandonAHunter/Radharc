using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PryshoreManager : MonoBehaviour {
	public GameObject skylar;

	// Use this for initialization
	void Start () {
		if (GameManager.Instance.DialogVariables ["$glasses"].AsNumber == 2) {
			skylar.SetActive (true);
		}
	}
}
