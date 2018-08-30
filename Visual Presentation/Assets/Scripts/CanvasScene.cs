using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScene : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MainMenuButton () {
		//Ask to Save

		//Ask to leave
		GameManager.Instance.MainMenu ();
	}

	public void PresentationButton () {
		if (GameManager.Instance.saveName == "") {
			//SaveFirst
		} else {
			//AutoSave to SaveName
			GameManager.Instance.PresentationMode ();
		}
	}
}
