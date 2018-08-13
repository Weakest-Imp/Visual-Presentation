using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Register : MonoBehaviour {

	public Presentation presentation;
	Camera mainCamera;
	CameraMovement cameraMovement;
	public string filePath = "C:\\Users\\Quentin\\Desktop\\Quentin\\images\\Fonds d'écran\\Digimon-Survive.jpg";
	string savePath;

	int pointer;

	void Start ()
	{
		presentation = ScriptableObject.CreateInstance<Presentation> ();
		mainCamera = GetComponent<Camera> ();
		cameraMovement = GetComponent<CameraMovement> ();
	}

	public int GetPointer ()
	{
		return pointer;
	}
	public void SetPointer(int newPosition)
	{
		if (newPosition >= 0 && newPosition < presentation.slides.Count) {
			pointer = newPosition - 1;}
	}
	public void SetPointerFromString (string newPosition)
	{
		Debug.Log (newPosition);
		int pos = int.Parse (newPosition);
		SetPointer (pos);
	}

	public bool IsEmpty ()
	{
		if (presentation.slides.Count == 0) {
			return true;
		} else {
			return false;
		}
	}

	//Change the Selected slide
	public void PointerPlus ()
	{
		pointer++;
		if (pointer >= presentation.slides.Count) {
			pointer = 0;
		}
		Debug.Log (pointer);
	}
	public void PointerMinus ()
	{
		pointer--;
		if (pointer < 0) {
			pointer = presentation.slides.Count-1;
			if (pointer == -1) {pointer = 0;}
		}
		Debug.Log (pointer);
	}
	public void PointerJump (int index)
	{
		if (index < presentation.slides.Count && index >= 0) {
			pointer = index;
		}
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

	public void DeleteSlide ()
	{
		if (!this.IsEmpty ()) {
			presentation.slides.RemoveAt (pointer);
			if (pointer >= presentation.slides.Count) {
				pointer--;
			}
			if (pointer == -1) {
				pointer = 0;
			}
			Debug.Log ("DELETED");
		}
	}

	public void ChangeOrder(string position)
	//Moves a slide from one position to another, 
	{
		int newPosition = int.Parse(position) - 1;
		Slide movingSlide = presentation.slides[pointer];
		presentation.slides.Insert (newPosition, movingSlide);
		presentation.slides.RemoveAt (pointer+1);
		Debug.Log ("MOVED!");
	}

	public void GoToSlide ()
	{
		cameraMovement.Relocate (presentation.slides[pointer]);
	}

//	public void Save ()
//	{
//		string savePath = Application.dataPath + "/Resources/Presentations/Current";
//		if (!Directory.Exists(savePath))
//			CreateSaveDirectory ();
//
//		string saveName = string.Format("Assets/Resources/Presentations/Current/{1}.asset", savePath, name);
//		AssetDatabase.CreateAsset(presentation, saveName);
//		//AssetDatabase.CreateAsset ();
//	}
//	public void CreateSaveDirectory ()
//	{
//		string savePath = Application.dataPath + "/Resources";
//		if (!Directory.Exists(savePath))
//			AssetDatabase.CreateFolder("Assets", "Resources");
//		savePath += "/Presentations";
//		if (!Directory.Exists(savePath))
//			AssetDatabase.CreateFolder("Assets/Resources", "Presentations");
//		savePath += "/Current";
//		if (!Directory.Exists(savePath))
//			AssetDatabase.CreateFolder("Assets/Resources/Presentations", "Current");
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
