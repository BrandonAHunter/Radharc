using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	void OnMouseDown(){
		SceneManager.LoadScene("Locations/" + this.gameObject.name);
	}
	public void goToMap(){
		SceneManager.LoadScene("Locations/Map");
	}
	public void goToScene(string name){
		SceneManager.LoadScene(name);
	}
}
