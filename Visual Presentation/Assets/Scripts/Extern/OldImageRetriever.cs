using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldImageRetriever : MonoBehaviour {

	string filePath = "https://www.pokepedia.fr/images/thumb/0/0b/Arceus-HGSS2.png/250px-Arceus-HGSS2.png";
	Texture2D img;

	// Use this for initialization
	void Start () {
		StartCoroutine (LoadImg());
	}

	IEnumerator LoadImg()
	{
	 	yield return 0;
		WWW imgLink = new WWW (filePath);
		yield return imgLink;
		img = imgLink.texture;
	}

	void OnGUI () {
		GUILayout.Label (img);
	}

}
