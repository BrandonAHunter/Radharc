﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour {

	public GameObject[] inventory;

	void Update () {
		if (GameManager.Instance.DialogVariables ["$box"].AsBool) {
			inventory [0].SetActive (true);
		}
		else{
			inventory [0].SetActive (false);
		}
		if (GameManager.Instance.DialogVariables ["$fruit"].AsNumber > 0) {
			inventory [1].SetActive (true);
			inventory [1].GetComponentInChildren<Text> ().text = GameManager.Instance.DialogVariables ["$fruit"].AsNumber +"";
		}
	}

	public void OpenBox(){
		SceneManager.LoadScene ("PryShore/Wooden Box/Wooden Box");
	}
}
