using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private string _lastScene = "None";
	private bool _invActive = false;
	private bool _dialogActive = false;
	private bool _letter = false;
	private bool _AderToPryshore = false;
	private bool _AderToFairmount = false;
	private bool _FairmountToTalgor = false;
	private float _textSpeed = 0.025f;
	private float _musicVolume = 1.0f;
	private float _SFXVolume = 0.75f;
	private string _saveFile;
	private Dictionary<string, Yarn.Value> variables = new Dictionary<string, Yarn.Value> ();

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
	public bool Letter { 
		get{
			return this._letter;
		}
		set {
			this._letter = value;
		}
	}
	public bool AderToPryshore { 
		get{
			return this._AderToPryshore;
		}
		set {
			this._AderToPryshore = value;
		}
	}
	public bool AderToFairmount { 
		get{
			return this._AderToFairmount;
		}
		set {
			this._AderToFairmount = value;
		}
	}
	public bool FairmountToTalgor { 
		get{
			return this._FairmountToTalgor;
		}
		set {
			this._FairmountToTalgor = value;
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
	public float musicVolume { 
		get{
			return this._musicVolume;
		}
		set {
			this._musicVolume = value;
		}
	}
	public float SFXVolume { 
		get{
			return this._SFXVolume;
		}
		set {
			this._SFXVolume = value;
		}
	}
	public Dictionary<string, Yarn.Value> DialogVariables{
		get{
			return this.variables;
		}
		set {
			this.variables = value;
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