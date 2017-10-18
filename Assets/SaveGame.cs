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
		writer.WriteLine(GameManager.Instance.Name);
		writer.WriteLine(GameManager.Instance.LastScene);
		writer.WriteLine(GameManager.Instance.Progress);
		writer.WriteLine(GameManager.Instance.Key);
		writer.WriteLine(GameManager.Instance.Glasses);
		writer.WriteLine(GameManager.Instance.Fish);
		writer.WriteLine(GameManager.Instance.SmWheel);
		writer.WriteLine(GameManager.Instance.MdWheel);
		writer.WriteLine(GameManager.Instance.LgWheel);
		writer.WriteLine(GameManager.Instance.Inventory);
		writer.WriteLine(GameManager.Instance.Dialog);
		writer.Close();
		Debug.Log ("Saved Game");
	}

	public void Load(string fileName)
	{
		string path = "Saves/" + fileName;

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path);

		GameManager.Instance.Name = reader.ReadLine();
		GameManager.Instance.LastScene = reader.ReadLine();
		GameManager.Instance.Progress = System.Convert.ToInt32(reader.ReadLine());
		GameManager.Instance.Key = System.Convert.ToInt32(reader.ReadLine());
		GameManager.Instance.Glasses = System.Convert.ToInt32(reader.ReadLine());
		GameManager.Instance.Fish = reader.ReadLine() == "true";
		GameManager.Instance.SmWheel = reader.ReadLine() == "true";
		GameManager.Instance.MdWheel = reader.ReadLine() == "true";
		GameManager.Instance.LgWheel = reader.ReadLine() == "true";
		GameManager.Instance.Inventory = reader.ReadLine() == "true";
		GameManager.Instance.Dialog = reader.ReadLine() == "true";

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
		GameManager.Instance.Name = name;
	}

	void Start(){
		GameManager.Instance.Name = "Somerled";
		string path = "Saves/Save1.txt";

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path);

		save1.text = reader.ReadLine () + " " + reader.ReadLine ();

		reader.Close();
		path = "Saves/Save2.txt";

		reader = new StreamReader(path);

		save2.text = reader.ReadLine () + " " + reader.ReadLine ();

		reader.Close();
		path = "Saves/Save3.txt";

		reader = new StreamReader(path);

		save3.text = reader.ReadLine () + " " + reader.ReadLine ();

		reader.Close();
	}
}
