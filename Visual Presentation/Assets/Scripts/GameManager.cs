using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; private set; }

	public string filePath = "C:\\Users\\Quentin\\Desktop\\Quentin\\images\\Fonds d'écran\\Digimon-Survive.jpg";
	public string saveName;

	public Presentation presentation;

	//Register register;

	void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public void SetSaveName (string saveName)
	{
		this.saveName = saveName;
	}
	public void SetFilePath (string filePath)
	{
		this.filePath = filePath;
	}
	public void SetPresentation (Presentation presentation)
	{
		this.presentation = presentation;
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene ("ModeScreen");
	}

	public void EditorMode ()
	{
		SceneManager.LoadScene ("EditionMode");
	}

	public void PresentationMode ()
	{
		SceneManager.LoadScene ("PresentationMode");
	}
}
