using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int _progress = 0;
	private int _keyPeices = 0;
	private int _glassesPeices = 0;
	private bool _fish = false;
	private bool _smallWheel = false;
	private bool _medWheel_Correct = false;
	private bool _lgWheel = false;
	private string _name;
	private bool _invActive = false;
	private bool _dialogActive = false;
	private string _lastScene = "Ader";
	private float _textSpeed = 0.05f;
	private string _saveFile;
	private bool _boxInv = false;
	private bool _boxComp = false;

	public int Progress { 
		get{
			return this._progress;
		}
		set {
			this._progress = value;
		}
	}
	public int Key { 
		get{
			return this._keyPeices;
		}
		set {
			this._keyPeices = value;
		}
	}
	public int Glasses { 
		get{
			return this._glassesPeices;
		}
		set {
			this._glassesPeices = value;
		}
	}
	public bool Fish { 
		get{
			return this._fish;
		}
		set {
			this._fish = value;
		}
	}
	public bool SmWheel { 
		get{
			return this._smallWheel;
		}
		set {
			this._smallWheel = value;
		}
	}
	public bool MdWheel { 
		get{
			return this._medWheel_Correct;
		}
		set {
			this._medWheel_Correct = value;
		}
	}
	public bool LgWheel { 
		get{
			return this._lgWheel;
		}
		set {
			this._lgWheel = value;
		}
	}
	public string Name { 
		get{
			return this._name;
		}
		set {
			this._name = value;
		}
	}
	public bool Inventory { 
		get{
			return this._invActive;
		}
		set {
			this._invActive = value;
		}
	}
	public bool Dialog { 
		get{
			return this._dialogActive;
		}
		set {
			this._dialogActive = value;
		}
  	}
	public string LastScene { 
		get{
			return this._lastScene;
		}
		set {
			this._lastScene = value;
		}
	}
	public string SaveFile { 
		get{
			return this._saveFile;
		}
		set {
			this._saveFile = value;
		}
	}
	public float TextSpeed { 
		get{
			return this._textSpeed;
		}
		set {
			this._textSpeed = value;
		}
	}

	private GameManager()
	{
	}

	public static GameManager Instance { get { return Nested.instance; } }

	private class Nested
	{
		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static Nested()
		{
		}

		internal static readonly GameManager instance = new GameManager();
	}
}