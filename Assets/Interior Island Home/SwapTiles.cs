using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTiles : MonoBehaviour {
	private GameObject[,] tiles;
	private GameObject[,] awnserKey;
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
		awnserKey = tiles;
		//randomizes the tiles
		for (int i = 0; i < 4; i++) {
			for(int j = 0; j < 4; j++){
				xPos = i;
				yPos = j;
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
						for (int i = 0; i < 4; i++) {
							for (int j = 0; j < 4; j++) {
								tiles [i, j].gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
							}
						}
						//First Click
						if (!clickedOnce) {
							for (int i = 0; i < 4; i++) {
								for (int j = 0; j < 4; j++) {
									if (tiles [i, j].gameObject == hit.collider.gameObject) {
										ChangeColor (i - 1, j);
										ChangeColor (i + 1, j);
										ChangeColor (i, j - 1);
										ChangeColor (i, j + 1);
										clickedOnce = true;
										xPos = i;
										yPos = j;
									}
								}
							}
						}  
					//Second Click
					else {
							if (xPos > 0 && tiles [xPos - 1, yPos].gameObject == hit.collider.gameObject) {
								Swap2Tiles (xPos - 1, yPos);
							}
							if (xPos < 3 && tiles [xPos + 1, yPos].gameObject == hit.collider.gameObject) {
								Swap2Tiles (xPos + 1, yPos);
							}
							if (yPos > 0 && tiles [xPos, yPos - 1].gameObject == hit.collider.gameObject) {
								Swap2Tiles (xPos, yPos - 1);
							}
							if (yPos < 3 && tiles [xPos, yPos + 1].gameObject == hit.collider.gameObject) {
								Swap2Tiles (xPos, yPos + 1);
							}
							clickedOnce = false;
						}
					}
				}
			}
			GameOver = true;
			for (int i = 0; i < 4; i++) {
				for(int j = 0; j < 4; j++){
					if (tiles [i, j] != GameObject.Find ("TilePuzzle" + i + "" + j))
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
