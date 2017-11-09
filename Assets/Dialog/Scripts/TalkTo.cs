using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class TalkTo : MonoBehaviour {
	private bool talking = false;
	void OnMouseDown(){
		if (!talking) {
			talking = true;
			FindObjectOfType<DialogueRunner> ().StartDialogue (this.gameObject.GetComponent<NPC> ().talkToNode);
		}
		if (talking && ! FindObjectOfType<DialogueRunner> ().isDialogueRunning) {
			talking = false;
		}
	}
}
