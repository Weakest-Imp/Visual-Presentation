using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class OpenSaveFiles : MonoBehaviour {

	string savePath;
	string[] saves;

	[SerializeField] GameObject button;
	[SerializeField] Transform list;

	void Start () {
		savePath = Application.dataPath + "/Resources/Presentations";
		saves = Directory.GetDirectories (savePath);
		foreach (string saveNamePath in saves) {
			string saveName = saveNamePath.Replace(savePath + "\\", ""); 
			CreateButton (saveName);
		}
	}


	void CreateButton(string saveName) {
		GameObject newButton = (GameObject)Instantiate (button);

		//Makes sure the new button is in the list
		newButton.transform.parent = list;

		Text buttonText = newButton.GetComponentInChildren<Text> ();
		buttonText.text = saveName;

	}
}
