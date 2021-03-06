﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CursorManager : MonoBehaviour {
	public Texture2D cursor;
	public Texture2D cursorHover;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	void OnMouseOver()
	{
		if (FindObjectOfType<DialogueRunner> () != null) {
			if (!FindObjectOfType<DialogueRunner> ().isDialogueRunning)
				Clickable ();
		} else {
			Clickable ();
		}
	}

	void OnMouseExit()
	{
		Unclickable ();
	}

	void OnMouseDown()
	{
		Unclickable ();
	}

	void Start(){
		Unclickable ();
	}

	public void Clickable(){
		Cursor.SetCursor (cursorHover, hotSpot, cursorMode);
	}
	public void Unclickable(){
		Cursor.SetCursor(cursor, Vector2.zero, cursorMode);
	}

}
