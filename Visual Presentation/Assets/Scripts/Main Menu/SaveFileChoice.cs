using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFileChoice : MonoBehaviour {

	string buttonText;

	void Start () {
		buttonText = GetComponentInChildren<Text>().text;
	}

	public void LaunchEditor () {
		GameManager.Instance.SetSaveName (buttonText);
		GameManager.Instance.EditorMode ();
	}

	public void LaunchPresentation () {
		GameManager.Instance.SetSaveName (buttonText);
		GameManager.Instance.PresentationMode ();
	}
}
