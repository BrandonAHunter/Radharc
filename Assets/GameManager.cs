using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private bool _invActive = false;
	private bool _dialogActive = false;
	private string _lastScene = "Ader";
	private float _textSpeed = 0.025f;
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