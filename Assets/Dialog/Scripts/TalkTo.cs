using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class TalkTo : MonoBehaviour {
	private bool talking = false;
	void OnMouseDown(){
		if (!talking  && ! FindObjectOfType<DialogueRunner> ().isDialogueRunning) {
			talking = true;
			FindObjectOfType<DialogueRunner> ().StartDialogue (this.gameObject.GetComponent<NPC> ().talkToNode);
		}
	}

	void Update(){
		if (talking && ! FindObjectOfType<DialogueRunner> ().isDialogueRunning) {
			talking = false;
		}
	}
}
