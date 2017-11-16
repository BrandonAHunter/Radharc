using System.Collections;
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
		if (GameManager.Instance.DialogVariables ["$fish"].AsNumber == 1) {
			inventory [2].SetActive (true);
		}
		else{
			inventory [2].SetActive (false);
		}
		if (GameManager.Instance.DialogVariables ["$key"].AsNumber > 0) {
			inventory [3].SetActive (true);
			inventory [3].GetComponentInChildren<Text> ().text = GameManager.Instance.DialogVariables ["$key"].AsNumber +"";
		}
		if (GameManager.Instance.DialogVariables ["$glasses"].AsNumber > 0) {
			inventory [4].SetActive (true);
			inventory [4].GetComponentInChildren<Text> ().text = GameManager.Instance.DialogVariables ["$glasses"].AsNumber +"";
		}
	}

	public void OpenBox(){
		SceneManager.LoadScene ("Mini Games/Wooden Box");
	}
}
