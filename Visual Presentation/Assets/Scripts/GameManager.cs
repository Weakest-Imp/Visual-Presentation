using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; private set; }

	public string filePath = "C:\\Users\\Quentin\\Desktop\\Quentin\\images\\Fonds d'écran\\Digimon-Survive.jpg";
	public string saveName;

	Register register;

	void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene ("ModeScreen");
	}

	public void EditorMode ()
	{
		//apply filePath beforehand
		SceneManager.LoadScene ("EditionMode");
	}
}
