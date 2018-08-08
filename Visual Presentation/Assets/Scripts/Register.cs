using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Register : MonoBehaviour {

	Presentation presentation;
	Camera mainCamera;
	CameraMovement cameraMovement;

	void Start ()
	{
		presentation = ScriptableObject.CreateInstance<Presentation> ();
		mainCamera = GetComponent<Camera> ();
		cameraMovement = GetComponent<CameraMovement> ();
	}

	public void AddSlide ()
	//Create slide from current position and adds it
	{
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		float rot = this.transform.rotation.eulerAngles.z; //Probably won't work
		float zoom = mainCamera.orthographicSize;
		Slide slide = new Slide (x, y, rot, zoom);
		presentation.slides.Add (slide);
	}

	public void ChangeOrder(int oldPosition, int newPosition)
	//Moves a slide from one position to another, 
	{
		Slide movingSlide = presentation.slides[oldPosition];
		presentation.slides.Insert (newPosition, movingSlide);
		presentation.slides.RemoveAt (oldPosition);
	}

	public void GoToSlide (int slidePosition)
	{
		Debug.Log ("Going");
		if (slidePosition < presentation.slides.Count) {
			cameraMovement.Relocate (presentation.slides[slidePosition]);
			Debug.Log ("Sucess!");
		}
	}

//	public void Save ()
//	{
//		string filePath = Application.dataPath + "/Resources/Presentations";
//		if (!Directory.Exists(filePath))
//			CreateSaveDirectory ();
//
//		LevelData board = ScriptableObject.CreateInstance<LevelData>();
//		board.tiles = new List<Vector3>( tiles.Count );
//		foreach (Tile t in tiles.Values)
//			board.tiles.Add( new Vector3(t.pos.x, t.height, t.pos.y) );
//
//		string fileName = string.Format("Assets/Resources/Presentations/{1}.asset", filePath, name);
//		AssetDatabase.CreateAsset(board, fileName);
//	}
//	void CreateSaveDirectory ()
//	{
//		string filePath = Application.dataPath + "/Resources";
//		if (!Directory.Exists(filePath))
//			AssetDatabase.CreateFolder("Assets", "Resources");
//		filePath += "/Presentations";
//		if (!Directory.Exists(filePath))
//			AssetDatabase.CreateFolder("Assets/Resources", "Presentations");
//		AssetDatabase.Refresh();
//	}
//	public void Load ()
//	{
//		Clear();
//		if (levelData == null)
//			return;
//		foreach (Vector3 v in levelData.tiles)
//		{
//			Tile t = Create();
//			t.Load(v);
//			tiles.Add(t.pos, t);
//		}
//	}
}
