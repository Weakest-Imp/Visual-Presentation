using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

//Gives a sprite to the gameobject from the picture indicated by the user
public class ImageRetriever : MonoBehaviour {

	[SerializeField] GameObject mainCamera;
	[SerializeField] CameraMovement cameraMovement;
	public string filePath;

	private Texture2D imgTex;
	private Sprite image;
	private SpriteRenderer spriteR;

	void Start () {
			//It somehow does not find the cameraMovement this way, had to use SerializeField
		//mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		//cameraMovement = mainCamera.GetComponent<CameraMovement> ();

		filePath = GameManager.Instance.filePath;
	}


	public void ApplySpriteFromPath (string filePath) {
		imgTex = LoadPNG (filePath);
		image = Sprite.Create (imgTex, new Rect(0, 0, imgTex.width, imgTex.height), new Vector2(0.5f, 0.5f));
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		spriteR.sprite = image;
		cameraMovement.Initialize (imgTex.height/200f);
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
