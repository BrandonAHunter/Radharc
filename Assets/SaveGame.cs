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

	public void ReadSave(string FileName){
		string SaveFile = Application.persistentDataPath + "/" + FileName;
		try {
			if (File.Exists(SaveFile)) {
				StreamReader reader = new StreamReader(SaveFile);

				GameManager.Instance.LastScene = reader.ReadLine();
				GameManager.Instance.Inventory = reader.ReadLine() == "True";
				GameManager.Instance.Dialog = reader.ReadLine() == "True";
				GameManager.Instance.Letter = reader.ReadLine() == "True";
				GameManager.Instance.AderToPryshore = reader.ReadLine() == "True";
				GameManager.Instance.AderToFairmount = reader.ReadLine() == "True";
				GameManager.Instance.FairmountToTalgor = reader.ReadLine() == "True";
				GameManager.Instance.TextSpeed = float.Parse (reader.ReadLine ());
				GameManager.Instance.musicVolume = float.Parse (reader.ReadLine ());
				GameManager.Instance.SFXVolume = float.Parse (reader.ReadLine ());

				while (!reader.EndOfStream) {
					string line = reader.ReadLine ();
					string[] variable = line.Split('\t');
					if (variable.Length == 2) {
						GameManager.Instance.DialogVariables [variable [0]] = new Yarn.Value (variable [1]);
					}
					else if(variable[2] == "Bool"){
						if (variable [1] == "False") {
							GameManager.Instance.DialogVariables [variable [0]] = new Yarn.Value (false);
						} else {
							GameManager.Instance.DialogVariables [variable [0]] = new Yarn.Value (true);
						}
					}
					else if(variable[2] == "Number"){
						GameManager.Instance.DialogVariables [variable [0]] = new Yarn.Value (float.Parse(variable[1]));
					}
				}

				reader.Close();

				GameManager.Instance.SaveFile = FileName;
				if (GameManager.Instance.LastScene != "") {
					SceneManager.LoadScene (GameManager.Instance.LastScene);
					Debug.Log ("Loaded Game");
				} else {
					Debug.Log ("Cant load empty save");
				}
			}
			else {
				Debug.Log("Settings file does not exist. Creating new one");
				WriteSave(FileName);
				SceneManager.LoadScene ("Ader");
			}
		}
		catch {
			Debug.Log("Could not read settings text file");
		}

		Debug.Log("Load Save1 Complete");
	}

	public void WriteSave(string FileName){
		string SaveFile = Application.persistentDataPath + "/"  + FileName;
		try {
			if (File.Exists(SaveFile)) {
				File.Delete(SaveFile);
			}

			StreamWriter writer = File.CreateText(SaveFile);
			if(GameManager.Instance.LastScene == "Start Menu"){
				GameManager.Instance.LastScene = "Ader";
			}
			writer.WriteLine(GameManager.Instance.LastScene);
			writer.WriteLine(GameManager.Instance.Inventory);
			writer.WriteLine(GameManager.Instance.Dialog);
			writer.WriteLine(GameManager.Instance.Letter);
			writer.WriteLine(GameManager.Instance.AderToPryshore);
			writer.WriteLine(GameManager.Instance.AderToFairmount);
			writer.WriteLine(GameManager.Instance.FairmountToTalgor);
			writer.WriteLine(GameManager.Instance.TextSpeed);
			writer.WriteLine(GameManager.Instance.musicVolume);
			writer.WriteLine(GameManager.Instance.SFXVolume);

			foreach (KeyValuePair<string, Yarn.Value> variable in GameManager.Instance.DialogVariables) {
				if (variable.Value.type.ToString() == "String") {
					writer.WriteLine (variable.Key + "\t" + variable.Value.AsString);
				} else if (variable.Value.type.ToString() == "Bool") {
					writer.WriteLine (variable.Key + "\t" + variable.Value.AsBool + "\tBool");
				} else {
					writer.WriteLine (variable.Key + "\t" + variable.Value.AsNumber + "\tNumber");
				}

			}

			writer.Close();

			Debug.Log(FileName  + " Overwrite Complete");
		}
		catch {
			Debug.Log("Could not overwrite " + FileName);
		}
	}

	public void SelectSave(string name){
		GameManager.Instance.SaveFile = name;
		SceneManager.LoadScene("Ader");
	}

	void Start(){
		GameManager.Instance.DialogVariables["$name"] = new Yarn.Value("Somerled");
		string path = Application.persistentDataPath + "/" + "Save1.txt";
		if (File.Exists (path)) {
			//Read the text from directly from the test.txt file
			StreamReader reader = new StreamReader (path);

			save1.text = "Save 1: " + reader.ReadLine ();

			reader.Close();
		} else {
			WriteSave (path);

			save1.text = "Save 1: Empty Save";
		}

		path = Application.persistentDataPath + "/" + "Save2.txt";
		if (File.Exists (path)) {
			//Read the text from directly from the test.txt file
			StreamReader reader = new StreamReader (path);

			save2.text = "Save 2: " + reader.ReadLine ();

			reader.Close();
		} else {
			WriteSave (path);

			save2.text = "Save 2: Empty Save";
		}

		path = Application.persistentDataPath + "/" + "Save3.txt";
		if (File.Exists (path)) {
			//Read the text from directly from the test.txt file
			StreamReader reader = new StreamReader (path);

			save3.text = "Save 3: " + reader.ReadLine ();

			reader.Close();
		} else {
			WriteSave (path);

			save3.text = "Save 3: Empty Save";
		}
	}

	public void BackToMenu(){
		SceneManager.LoadScene ("Start Menu");
	}
}
