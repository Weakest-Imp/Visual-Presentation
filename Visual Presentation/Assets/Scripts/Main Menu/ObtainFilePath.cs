using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObtainFilePath : MonoBehaviour {

	public void ObtainPath () {
		GameManager.Instance.SetFilePath(
			EditorUtility.OpenFilePanel ("Select file", "", ""));
		Debug.Log (GameManager.Instance.filePath);
	}
}
