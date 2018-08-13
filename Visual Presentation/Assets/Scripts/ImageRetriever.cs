using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

//Gives a sprite to the gameobject from the picture indicated by the user
public class ImageRetriever : MonoBehaviour {

	GameObject mainCamera;
	CameraMovement cameraScript;
	public string filePath = "C:\\Users\\Quentin\\Desktop\\Quentin\\images\\Fonds d'écran\\Digimon-Survive.jpg";

	private Texture2D imgTex;
	private Sprite image;
	private SpriteRenderer spriteR;

	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cameraScript = (CameraMovement) mainCamera.GetComponent (typeof(CameraMovement));
		//________filePath = ObtainUserPath ();_______
		ApplySpriteFromPath (filePath);
	}


	public void ApplySpriteFromPath (string filePath) {
		imgTex = LoadPNG (filePath);
		image = Sprite.Create (imgTex, new Rect(0, 0, imgTex.width, imgTex.height), new Vector2(0.5f, 0.5f));
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		spriteR.sprite = image;
		cameraScript.Initialize (imgTex.height/200f);
	}

	public static Texture2D LoadPNG(string filePath)
	//Converts image from filePath to a Texture2D
	{
		Texture2D tex = null;
		byte[] fileData;

		if (File.Exists (filePath)) {
			fileData = File.ReadAllBytes (filePath);
			tex = new Texture2D (2, 2);
			tex.LoadImage (fileData); //..this will auto-resize the texture dimensions.
		}

		return tex;
	}

	public Texture2D ImgTexture ()
	{
		return imgTex;
	}

}
