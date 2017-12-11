using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour {

	public GameObject[] inventory;
	private List<GameObject> ActiveInventory;
	private List<GameObject> SeenInventory;
	private int index = 0;

	void Start(){
		ActiveInventory = new List<GameObject>();
		SeenInventory = new List<GameObject>();

		inventory [0].SetActive (true);
		ActiveInventory.Add (inventory [0]);
	}

	void Update () {
		if (GameManager.Instance.DialogVariables ["$box"].AsBool) {
			if (! inventory [5].activeInHierarchy) {
				inventory [5].SetActive (true);
				ActiveInventory.Add (inventory [5]);
			}
		}
		else{
			if (inventory [5].activeInHierarchy) {
				inventory [5].SetActive (false);
				ActiveInventory.Remove (inventory [5]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$fruit"].AsNumber > 0) {
			if (! inventory [1].activeInHierarchy) {
				inventory [1].SetActive (true);
				ActiveInventory.Add (inventory [1]);
			}
			inventory [1].GetComponentInChildren<Text> ().text = GameManager.Instance.DialogVariables ["$fruit"].AsNumber + "";
		}
		if (GameManager.Instance.DialogVariables ["$fish"].AsNumber == 1) {
			if (! inventory [2].activeInHierarchy) {
				inventory [2].SetActive (true);
				ActiveInventory.Add (inventory [2]);
			}
		}
		else{
			if (inventory [2].activeInHierarchy) {
				inventory [2].SetActive (false);
				ActiveInventory.Remove (inventory [2]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$key"].AsNumber >= 1) {
			if (!inventory [3].activeInHierarchy) {
				inventory [3].SetActive (true);
				ActiveInventory.Add (inventory [3]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$key"].AsNumber >= 2) {
			if (!inventory [8].activeInHierarchy) {
				inventory [8].SetActive (true);
				ActiveInventory.Add (inventory [8]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$key"].AsNumber >= 3) {
			if (!inventory [9].activeInHierarchy) {
				inventory [9].SetActive (true);
				ActiveInventory.Add (inventory [9]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$key"].AsNumber >= 4) {
			if (!inventory [10].activeInHierarchy) {
				inventory [10].SetActive (true);
				ActiveInventory.Add (inventory [10]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$glasses"].AsNumber > 0) {
			if (!inventory [4].activeInHierarchy) {
				inventory [4].SetActive (true);
				ActiveInventory.Add (inventory [4]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$glasses"].AsNumber > 1) {
			if (!inventory [11].activeInHierarchy) {
				inventory [11].SetActive (true);
				ActiveInventory.Add (inventory [11]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$glasses"].AsNumber > 2) {
			if (!inventory [12].activeInHierarchy) {
				inventory [12].SetActive (true);
				ActiveInventory.Add (inventory [12]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$wheellg"].AsBool) {
			if (!inventory [6].activeInHierarchy) {
				inventory [6].SetActive (true);
				ActiveInventory.Add (inventory [6]);
			}
		} else {
			if (inventory [6].activeInHierarchy) {
				inventory [6].SetActive (false);
				ActiveInventory.Remove (inventory [6]);
			}
		}
		if (GameManager.Instance.DialogVariables ["$wheelsm"].AsBool) {
			if (!inventory [7].activeInHierarchy) {
				inventory [7].SetActive (true);
				ActiveInventory.Add (inventory [7]);
			}
		} else {
			if (inventory [7].activeInHierarchy) {
				inventory [7].SetActive (false);
				ActiveInventory.Remove (inventory [7]);
			}
		}
		DisplayInventory ();
	}

	public void DisplayInventory(){
		for (int i = 0; i < SeenInventory.Count; i++) {
			if (ActiveInventory.Count - 1 >= i) {
				SeenInventory[i].transform.localPosition = new Vector3 (500.0f, 170.0f, 0);
			}
		}

		SeenInventory.RemoveRange(0,SeenInventory.Count);

		for (int i = index; i < index + 5; i++) {
			if (ActiveInventory.Count - 1 >= i) {
				SeenInventory.Add (ActiveInventory [i]);
			}
		}

		for (int i = 0; i < SeenInventory.Count; i++) {
			SeenInventory [i].transform.localPosition = new Vector3 (370.0f, (170.0f - 50.0f * i), 0);
		}
	}

	public void changeIndex(int num){
		if ((index != 0 && num == -1) || (index <= ActiveInventory.Count-6 && num == 1)) {
			index += num;
		}
	}
}
