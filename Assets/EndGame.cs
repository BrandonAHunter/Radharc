using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	public GameObject tbc;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
		StartCoroutine(TBC());
	}
	
	IEnumerator TBC()
	{
		yield return new WaitForSeconds(3);
		tbc.SetActive(true);
		canvas.SetActive(true);
	}

	public void ExitGame(){
		Application.Quit();
	}
}
