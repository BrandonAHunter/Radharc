using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour {
	public Text save1;
	public Text save2;
	public Text save3;

	public void Save(string fileName)
	{
		string path = "Saves/" + fileName;

		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, false);

		writer.WriteLine(GameManager.Instance.LastScene);
		writer.WriteLine(GameManager.Instance.Inventory);
		writer.WriteLine(GameManager.Instance.Dialog);

		foreach (KeyValuePair<string, Yarn.Value> variable in GameManager.Instance.DialogVariables) {
			writer.WriteLine (variable.Key + "\t" + variable.Value);
		}

		writer.Close();
		Debug.Log ("Saved Game");
	}

	public void Load(string fileName)
	{
		string path = "Saves/" + fileName;

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path);

		GameManager.Instance.LastScene = reader.ReadLine();
		GameManager.Instance.Inventory = reader.ReadLine() == "true";
		GameManager.Instance.Dialog = reader.ReadLine() == "true";

		while (!reader.EndOfStream) {
			string line = reader.ReadLine ();
			string[] variable = line.Split('\t');
			GameManager.Instance.DialogVariables[variable [0]] = new Yarn.Value(variable [1]);
		}

		reader.Close();

		GameManager.Instance.SaveFile = fileName;
		if (GameManager.Instance.LastScene != "") {
			SceneManager.LoadScene (GameManager.Instance.LastScene);
			Debug.Log ("Loaded Game");
		} else {
			Debug.Log ("Cant load empty save");
		}
	}

	public void SelectSave(string name){
		GameManager.Instance.SaveFile = name;
		SceneManager.LoadScene("Ader");
	}

	public void EnteredName(string name){
		GameManager.Instance.DialogVariables["$name"] = new Yarn.Value(name);
	}

	void Start(){
		GameManager.Instance.DialogVariables["$name"] = new Yarn.Value("Somerled");
		string path = "Saves/Save1.txt";

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path);

		save1.text =  "Save 1: " + reader.ReadLine ();

		reader.Close();
		path = "Saves/Save2.txt";

		reader = new StreamReader(path);

		save2.text = "Save 2: " + reader.ReadLine ();

		reader.Close();
		path = "Saves/Save3.txt";

		reader = new StreamReader(path);

		save3.text = "Save 3: " + reader.ReadLine ();

		reader.Close();
	}
}
