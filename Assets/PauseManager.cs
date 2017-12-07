using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	public void Save(){
		SaveGame s = new SaveGame ();
		s.WriteSave (GameManager.Instance.SaveFile);
	}
	public void Exit(){
		Application.Quit ();
	}
	public void Resume(){
		SceneManager.LoadScene (GameManager.Instance.LastScene);
	}
}
