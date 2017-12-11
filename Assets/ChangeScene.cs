using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	void Start(){
		if (SceneManager.GetActiveScene ().name != "Map" && SceneManager.GetActiveScene ().name != "Options Menu"
			&& SceneManager.GetActiveScene ().name != "Letter" && SceneManager.GetActiveScene ().name != "Pause"
			&& SceneManager.GetActiveScene ().name != "Credits") {
			GameManager.Instance.LastScene = SceneManager.GetActiveScene ().name;
		}
	}
	void OnMouseDown(){
		SceneManager.LoadScene(this.gameObject.name);
	}
	public void goToMap(){
		SceneManager.LoadScene("Locations/Map", LoadSceneMode.Single);
	}
	public void goToScene(string name){
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
	public void goToLastScene(){
		if (GameManager.Instance.LastScene == "none") {
			SceneManager.LoadScene ("Start Menu", LoadSceneMode.Single);
		} else {
			SceneManager.LoadScene (GameManager.Instance.LastScene, LoadSceneMode.Single);
		}
	}
}
