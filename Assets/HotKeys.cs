using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class HotKeys : MonoBehaviour {
	public GameObject inventoryPanel;
	private SaveGame s;
	public GameObject letter;

	void Start(){
		s = new SaveGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inventoryPanel.activeInHierarchy != GameManager.Instance.Inventory) {
			inventoryPanel.SetActive (GameManager.Instance.Inventory);
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			GameManager.Instance.Inventory = !GameManager.Instance.Inventory;
		}
		if (FindObjectOfType<DialogueRunner> () == null || !FindObjectOfType<DialogueRunner> ().isDialogueRunning) {
			if (Input.GetKeyDown (KeyCode.M)) {
				GameManager.Instance.LastScene = SceneManager.GetActiveScene ().name;
				SceneManager.LoadScene ("Locations/Map");
			}
			if (Input.GetKeyDown (KeyCode.S) && !GameManager.Instance.Dialog) {
				s.WriteSave (GameManager.Instance.SaveFile);
			}
			if (Input.GetKeyDown (KeyCode.P)) {
				SceneManager.LoadScene ("Pause");
			}
			if (letter.activeInHierarchy && Input.GetMouseButtonDown (0)) {
				letter.SetActive (false);
				BoxCollider[] disable = GameObject.FindObjectsOfType<BoxCollider> ();
				for (int i = 0; i < disable.Length; i++) {
					disable [i].enabled = true;
				}
			}
		}
	}
}
