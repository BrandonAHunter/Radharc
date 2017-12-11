using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalgorManager : MonoBehaviour {
	public GameObject noWheel;
	public GameObject withWheel;
	public GameObject Cave;

	void Start () {
		if(GameManager.Instance.DialogVariables["$key"].AsNumber >= 2){
			Cave.SetActive (false);
		}
	}
	void Update () {
		if (GameManager.Instance.DialogVariables ["$wheelLgGet"].AsBool) {
			noWheel.SetActive (false);
			withWheel.SetActive (true);
		}
	}
}
