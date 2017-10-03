using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwlPicker : MonoBehaviour {
	public GameObject owl;
	public GameObject[] objects;
	public Text turn;
	public Text count;
	public Text gameOver;

	private GameObject[] order;
	private const int MAX_SIZE = 10;
	private int size = 1; 
	private int index = 0;
	private bool playersTurn = false;
	private bool ComputerPlaying = false;
	private bool GameOver = false;

	// Use this for initialization
	void Start () {
		order = new GameObject[MAX_SIZE];
		for (int i = 0; i < MAX_SIZE; i++) {
			order [i] = objects [Random.Range (0, objects.Length)];
			Debug.Log (order [i]);
		}
		count.text = size + "/" + MAX_SIZE;
	}
	// Update is called once per frame
	void Update () {
		if (!GameOver) {
			if (! playersTurn && ! ComputerPlaying) {
				turn.text = "Computer Turn";
				ComputerPlaying = true;
				index = 0;
				InvokeRepeating ("OwlPicks", 1.0f, 1.0f);
				InvokeRepeating ("ResetOwlLocation", 1.5f, 1.0f);
			} else if(playersTurn) {
				if (Input.GetMouseButtonDown (0)) {
					RaycastHit hit = new RaycastHit ();        
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

					if (Physics.Raycast (ray, out hit)) {
						if (hit.collider.tag == "Object") {
							if (order [index].gameObject == hit.collider.gameObject) {
								index++;
							} else {
								gameOver.text = "Game Lost";
								gameOver.color = Color.red;
								GameOver = true;
							}
							if (index == size) {
								size++;
								count.text = size + "/" + MAX_SIZE;
								playersTurn = false;
								index = 0;
							}
						}
					}
				}
			}
			if (size == MAX_SIZE) {
				GameOver = true;
				gameOver.text = "Game Won";
				gameOver.color = Color.yellow;
			}
		}
	}
	void OwlPicks(){
		if (index == size) {
			turn.text = "Players Turn";
			playersTurn = true;
			ComputerPlaying = false;
			owl.transform.position = new Vector3 (0, 3, 0);
			index = 0;
			CancelInvoke ();
		} else {
			owl.transform.position = order [index].transform.position;
			index++;
		}
	}
	void ResetOwlLocation(){
		owl.transform.position = new Vector3 (0, 3, 0);
	}
}
