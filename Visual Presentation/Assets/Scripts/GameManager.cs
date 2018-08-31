using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; private set; }

	public string filePath = "C:\\Users\\Quentin\\Desktop\\Quentin\\images\\Fonds d'écran\\Digimon-Survive.jpg";
	public string saveName;

	public Presentation presentation;

	string previousScene;

	//Register register;

	void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		previousScene = SceneManager.GetActiveScene ().name;
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
		SetFilePath ("");
		SetSaveName ("");
		SetPresentation (new Presentation());
		previousScene = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene ("ModeScreen");
	}

	public void EditorMode ()
	{
		previousScene = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene ("EditionMode");
	}

	public void PresentationMode ()
	{
		previousScene = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene ("PresentationMode");
	}

	public void PreviousScene ()
	{
		SceneManager.LoadScene (previousScene);
	}
}
