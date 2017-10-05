using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTiles : MonoBehaviour {
	private GameObject[,] tiles;
	private bool clickedOnce = false;
	private int xPos;
	private int yPos;
	private bool GameOver = false;
	// Use this for initialization
	void Start () {
		//Initalizes all the tiles
		tiles = new GameObject[4, 4];
		for (int i = 0; i < 4; i++) {
			for(int j = 0; j < 4; j++){
				tiles[i,j] = GameObject.Find("TilePuzzle" + i + "" + j);
			}
		}
		//randomizes the tiles
		for (int i = 0; i < 4; i++) {
			for(int j = 0; j < 4; j++){
				xPos = i;
				yPos = j;
				tiles [i, j].transform.Rotate (0, 0, Random.Range (0, 4) * 90);
				Swap2Tiles (Random.Range (0, 4), Random.Range (0, 4));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOver) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit = new RaycastHit ();        
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag == "Tile") {
						//Reset Colors
						tiles [xPos, yPos].gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
						//First Click
						if (!clickedOnce) {
							for (int i = 0; i < 4; i++) {
								for (int j = 0; j < 4; j++) {
									if (tiles [i, j].gameObject == hit.collider.gameObject) {
										ChangeColor (i, j);
										clickedOnce = true;
										xPos = i;
										yPos = j;
									}
								}
							}
						}  
						//Second Click
						else {
							for (int i = 0; i < 4; i++) {
								for (int j = 0; j < 4; j++) {
									if (tiles [xPos, yPos].gameObject != tiles [i, j] && tiles [i, j] == hit.collider.gameObject) {
										Swap2Tiles (i, j);
									}
								}
							}
							clickedOnce = false;
						}
					}
				}
			}
			else if(Input.GetMouseButtonDown (1)){
				if (clickedOnce) {
					clickedOnce = false;
					tiles [xPos, yPos].gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				RaycastHit hit = new RaycastHit ();        
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag == "Tile") {
						hit.collider.gameObject.transform.Rotate (0, 0, 90);
					}
				}
			}
			GameOver = true;
			for (int i = 0; i < 4; i++) {
				for(int j = 0; j < 4; j++){
					if (tiles [i, j] != GameObject.Find ("TilePuzzle" + i + "" + j) || tiles[i,j].transform.localEulerAngles != new Vector3(0,0,0))
						GameOver = false;
				}
			}
		}
	}

	void Swap2Tiles(int x, int y){
		GameObject temp = tiles [xPos, yPos];
		Vector3 tempPos = tiles [xPos, yPos].transform.position;
		tiles [xPos, yPos].transform.position = tiles [x, y].transform.position;
		tiles [x, y].transform.position = tempPos;
		tiles [xPos, yPos] = tiles [x, y];
		tiles [x, y] = temp;
	}
	void ChangeColor(int x, int y){
		if(x >= 0 && x <=3 && y >= 0 && y <=3)
			tiles [x, y].gameObject.GetComponent<SpriteRenderer> ().color = Color.yellow;
	}
}
