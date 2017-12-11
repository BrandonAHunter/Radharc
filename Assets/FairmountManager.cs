﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairmountManager : MonoBehaviour {

	public GameObject noWheel;
	public GameObject withWheel;
	public GameObject TractorHover;

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.DialogVariables ["$tractor"].AsString == "fixed") {
			noWheel.SetActive (false);
			withWheel.SetActive (true);
		}
		if (GameManager.Instance.DialogVariables ["$tractor"].AsString == "fixed") {
			TractorHover.GetComponent<NPCHover> ().npcHover = null;
		}
	}
}
