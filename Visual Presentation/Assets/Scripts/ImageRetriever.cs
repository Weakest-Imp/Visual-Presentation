using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

//Open a picture from the internet, not from the computer yet
public class ImageRetriever : MonoBehaviour {

	string filePath = "C:\\Users\\Quentin\\Desktop\\Quentin\\images\\Fonds d'écran";
	Texture2D img;

	// Use this for initialization
	void Start () {
		img = LoadPNG (filePath);
		//StartCoroutine (LoadImg());
	}

	//IEnumerator LoadImg()
	//{
	//	yield return 0;
	//	WWW imgLink = new WWW (filePath);
	//	yield return imgLink;
	//	img = imgLink.texture;
	//}

	// Update is called once per frame
	void OnGUI () {
		GUILayout.Label (img);
	}

	public static Texture2D LoadPNG(string filePath) {

		Texture2D tex = null;
		byte[] fileData;

		if (File.Exists (filePath)) {
			Debug.Log ("Le fichier est trouvé");
			fileData = File.ReadAllBytes (filePath);
			tex = new Texture2D (2, 2);
			tex.LoadImage (fileData); //..this will auto-resize the texture dimensions.
		}
		else 
		{
			Debug.Log ("Nope");
		}
		return tex;
	}

}
