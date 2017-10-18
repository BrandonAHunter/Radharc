using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour {
	private GameObject areaManager;

	// Use this for initialization
	void Start(){
		areaManager = GameObject.Find ("areaManager");
	}
	void OnMouseDown(){
		if (GameManager.Instance.Dialog == false) {
			areaManager.GetComponent<DialogManager> ().startConversation (this.gameObject.name);
		}
	}
}
