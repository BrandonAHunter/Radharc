using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class DialogManager : MonoBehaviour {
	public Text dialogBox;
	public Text continueBox;
	public Button[] choices;
	public GameObject dialogPanel;
	public GameObject inventoryPanel;
	public GameObject[] People;

	private int talkingToIndex;
	private int eanDialogNum;
	private int kyranDialogNum;
	private int fishermanDialogNum;
	private int homelessDialogNum;
	private string talkingTo;
	private string[] Dialog;
	private int DialogIndex;
	private string DialogNum;
	private int subDialogNum;
	private bool talking;
	private bool fileFound;
	private SaveGame s;

	void Start(){
		GameManager.Instance.LastScene = SceneManager.GetActiveScene().name;
		if (GameManager.Instance.Progress == 0) {
			startConversation ("ean");
			viewDialog ();
		}
		s = new SaveGame ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (talking && DialogIndex < Dialog.Length) {
				if (continueBox.enabled == true)
					viewDialog ();
				else
					continueBox.enabled = true;
			}
		}
		if (dialogPanel.activeInHierarchy != GameManager.Instance.Dialog) {
			dialogPanel.SetActive (GameManager.Instance.Dialog);
		}
		if (inventoryPanel.activeInHierarchy != GameManager.Instance.Inventory) {
			inventoryPanel.SetActive (GameManager.Instance.Inventory);
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			GameManager.Instance.LastScene = SceneManager.GetActiveScene ().name;
			SceneManager.LoadScene ("Locations/Map");
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			GameManager.Instance.Inventory = !GameManager.Instance.Inventory;
		}
		if (Input.GetKeyDown (KeyCode.S) && ! GameManager.Instance.Dialog) {
			s.Save (GameManager.Instance.SaveFile);
		}
	}

	string[] readfile(string filename){
		try{
			string[] testDataLineByLine = File.ReadAllLines("Assets/Dialog/"+filename);
			return testDataLineByLine;
		}
		catch(Exception e){
			GameManager.Instance.Dialog = false;
			fileFound = false;
			talking = false;
			return null;
		}
	}

	public void updateDialog(int choice){
		if (talkingTo == "ean" && GameManager.Instance.Progress == 0) {
			GameManager.Instance.Progress++;
		}
		else if (talkingTo == "kyran" && choice == 3 && GameManager.Instance.Progress == 1) {
			GameManager.Instance.Progress++;
		}
		else if (talkingTo == "homeless" && choice == 1 && GameManager.Instance.Progress == 3) {
			GameManager.Instance.Progress++;
		}
		else if (talkingTo == "kyran" && choice != 2 && GameManager.Instance.Progress == 4) {
			GameManager.Instance.Progress++;
		}
		Debug.Log (GameManager.Instance.Progress);
		subDialogNum += choice;
		DialogNum += "-" + subDialogNum;

		Dialog = readfile (talkingTo + "Dialog" + DialogNum + ".txt");

		DialogIndex = 0;
		subDialogNum = 0;
		for (int i = 0; i < choices.Length; i++) {
			choices [i].onClick.RemoveAllListeners ();
			choices [i].GetComponentInChildren<Text> ().text = "";
			choices [i].gameObject.SetActive (false);
		}
		if (Dialog != null)
			viewDialog ();
	}

	public void startConversation(string name){
		if (name == "ean") {
			if (GameManager.Instance.Progress == 0) {
				eanDialogNum = 1;
			}
			else if (GameManager.Instance.Progress >= 1) {
				eanDialogNum = 2;
			}
			DialogNum = eanDialogNum + "";
			talkingTo = "ean";
			talkingToIndex = 0;
		} else if (name == "kyran") {
			if (GameManager.Instance.Progress == 0) {
				kyranDialogNum = 0;
			}
			else if (GameManager.Instance.Progress < 2) {
				kyranDialogNum = 1;
			}
			else if (GameManager.Instance.Progress < 4){
				kyranDialogNum = 2;
			}
			else if (GameManager.Instance.Progress >= 4) {
				kyranDialogNum = 2;
			}
			DialogNum = kyranDialogNum + "";
			talkingTo = "kyran";
			talkingToIndex = 1;
		}else if (name == "fisherman") {
			if (GameManager.Instance.Progress == 2) {
				fishermanDialogNum = 1;
			} else if (GameManager.Instance.Progress >= 3) {
				fishermanDialogNum = 2;
			}
			DialogNum = fishermanDialogNum + "";
			talkingTo = "fisherman";
			talkingToIndex = 0;
		} else if (name == "homeless") {
			if (GameManager.Instance.Progress == 2) {
				homelessDialogNum = 1;
			}
			else if (GameManager.Instance.Progress == 3) {
				homelessDialogNum = 2;
			}
			else if (GameManager.Instance.Progress >= 4) {
				homelessDialogNum = 3;
			}
			DialogNum = homelessDialogNum + "";
			talkingTo = "homeless";
			talkingToIndex = 1;
		} else {
			return;
		}
		fileFound = true;
		Dialog = readfile (talkingTo + "Dialog" + DialogNum + ".txt");
		if (fileFound) {
			GameManager.Instance.Dialog = true;
			talking = true;
			//viewDialog ();
		}

	}

	void viewDialog(){
		Dialog [DialogIndex] = Dialog [DialogIndex].Replace ("$name", GameManager.Instance.Name);
		if (Dialog [DialogIndex].StartsWith ("N: ")) {
			People [talkingToIndex].SetActive (false);
			People [2].SetActive (false);
			StartCoroutine(TypeText (Dialog [DialogIndex].Replace ("N: ", "")));
		} else if (Dialog [DialogIndex].StartsWith ("L: ")) {
			People [talkingToIndex].SetActive (true);
			People [2].SetActive (false);
			StartCoroutine(TypeText (Dialog [DialogIndex].Replace ("L: ", "")));
		} else if (Dialog [DialogIndex].StartsWith ("R: ")) {
			People [talkingToIndex].SetActive (false);
			People [2].SetActive (true);
			StartCoroutine(TypeText (Dialog [DialogIndex].Replace ("R: ", "")));
		} else if (Dialog [DialogIndex].StartsWith ("M: ")) {
			dialogBox.text = "";
			People [talkingToIndex].SetActive (false);
			People [2].SetActive (true);
			for (int i = DialogIndex; i < Dialog.Length; i++) {
				int index = i - DialogIndex;
				choices [index].gameObject.SetActive (true);
				if (Dialog [i].StartsWith ("M: ")) {
					choices [index].GetComponentInChildren<Text> ().text = Dialog [i].Replace ("M: ", "");
					Debug.Log ("i: " + i + ", DialogIndex: " + DialogIndex);
					string name = Dialog [i].Replace ("M: ", "");
					choices [index].onClick.AddListener (delegate {
						changeScene (name);
					});
				} else {
					choices [index].GetComponentInChildren<Text> ().text = Dialog [i].Replace ("C: ", "");
					choices [index].onClick.AddListener (delegate {
						updateDialog ((index));
					});
				}
			}
			DialogIndex = Dialog.Length;
		} else if (Dialog [DialogIndex].StartsWith ("C: ")) {
			dialogBox.text = "";
			People [talkingToIndex].SetActive (false);
			People [2].SetActive (true);
			for (int i = DialogIndex; i < Dialog.Length; i++) {
				int index = i - DialogIndex;
				choices [index].gameObject.SetActive (true);
				choices [index].GetComponentInChildren<Text> ().text = Dialog [i].Replace ("C: ", "");
				choices [index].onClick.AddListener (delegate {updateDialog ((index + 1)); });
			}
			DialogIndex = Dialog.Length;
		}
		DialogIndex++;
	}

	IEnumerator TypeText (string message) {
		dialogBox.text = "";
		continueBox.enabled = false;
		foreach (char letter in message.ToCharArray()) {
			dialogBox.text += letter;
			if (continueBox.enabled == true)
				break;
			yield return new WaitForSeconds (GameManager.Instance.TextSpeed);
		}
		dialogBox.text = message;
		continueBox.enabled = true;
	}

	void changeScene(string name){
		GameManager.Instance.Dialog = false;
		SceneManager.LoadScene(name);
	}
}