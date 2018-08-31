using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScene : MonoBehaviour {

	[SerializeField] GameObject mainCamera;

	[SerializeField] GameObject MainMenuWindow1;
	[SerializeField] GameObject MainMenuWindow2;
	[SerializeField] GameObject SaveFirstWindow;

	// Use this for initialization
	void Start () {
		MainMenuWindow1.SetActive (false);
		MainMenuWindow2.SetActive (false); 
		SaveFirstWindow.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MainMenuButton () {
		MainMenuWindow1.SetActive (true);
	}
	public void AskToSave () {
		if (GameManager.Instance.saveName != "") {
			CloseMainMenu1 ();
			MainMenuWindow2.SetActive (true);
		} else {
			ToMainMenu ();
		}
	}
	public void Save () {
		mainCamera.GetComponent<Register> ().Save (GameManager.Instance.saveName);
	}
	public void ToMainMenu () {
		GameManager.Instance.MainMenu ();
	}

	public void PresentationButton () {
		if (GameManager.Instance.saveName == "") {
			SaveFirstWindow.SetActive (true); 
		} else {
			mainCamera.GetComponent<Register> ().Save (GameManager.Instance.saveName);
			GameManager.Instance.PresentationMode ();
		}
	}

	public void CloseMainMenu1 () {
		MainMenuWindow1.SetActive (false); 
	}
	public void CloseMainMenu2 () {
		MainMenuWindow2.SetActive (false); 
	}
	public void CloseSaveFirst () {
		SaveFirstWindow.SetActive (false); 
	}
}
