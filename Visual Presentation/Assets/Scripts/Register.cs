using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Register : MonoBehaviour {

	Presentation presentation;
	Camera mainCamera;
	CameraMovement cameraMovement;
	ImageRetriever imageRetriever;

	public string filePath;
	int pointer;

	string savePath;
	string saveName;

	void Start ()
	{
		presentation = new Presentation ();
		mainCamera = GetComponent<Camera> ();
		cameraMovement = GetComponent<CameraMovement> ();
		imageRetriever = GameObject.FindGameObjectWithTag ("Main Picture").GetComponent<ImageRetriever> ();
		filePath = GameManager.Instance.filePath;
		saveName = GameManager.Instance.saveName;
		Load (saveName);
	}

	public int GetPointer ()
	{
		return pointer;
	}
	public Slide GetSlide (int index)
	{
		return presentation.slides[index];
	}
	public int GetPointerRange ()
	{
		return presentation.slides.Count;
	}
	public bool PointerInRange (int index)
	//Evaluates wether index is within the bounds of the presentation
	{
		return (index < presentation.slides.Count && index >= 0);
	}
	public void SetPointer(int newPosition)
	{
		if (PointerInRange(newPosition - 1)) {
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
		if (!PointerInRange(pointer)) {
			pointer = 0;
		}
		Debug.Log (pointer);
	}
	public void PointerMinus ()
	{
		pointer--;
		if (!PointerInRange(pointer)) {
			pointer = presentation.slides.Count-1;
			if (pointer == -1) {pointer = 0;}
		}
		Debug.Log (pointer);
	}
	public void PointerJump (int index)
	{
		if (PointerInRange(index)) {
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

	public void Save (string newSaveName)
	{
		saveName = newSaveName;
		string savePath = Application.dataPath + "/Resources/Presentations/" + saveName;
		if (!Directory.Exists(savePath))
			CreateSaveDirectory (saveName);

		//Save base image
		FileUtil.CopyFileOrDirectory(filePath, savePath + "\\" + saveName + ".jpg");

		//Save Presentation
		BinaryFormatter binary = new BinaryFormatter ();
		FileStream fStream = File.Open (savePath + "\\" + saveName + ".pres", FileMode.OpenOrCreate);

		binary.Serialize (fStream, presentation);
		fStream.Close ();

		//InputField for name
		//Overwriting save but only for presentation
		AssetDatabase.Refresh();
	}

	void CreateSaveDirectory (string saveName)
	{
		savePath = Application.dataPath + "/Resources";
		if (!Directory.Exists(savePath))
			AssetDatabase.CreateFolder("Assets", "Resources");
		savePath += "/Presentations";
		if (!Directory.Exists(savePath))
			AssetDatabase.CreateFolder("Assets/Resources", "Presentations");
		savePath += "/" + saveName;
		if (!Directory.Exists(savePath))
			AssetDatabase.CreateFolder("Assets/Resources/Presentations", saveName);
		AssetDatabase.Refresh();
	}
	public void Load (string saveName)
	{
		if (saveName != "") {
			string savePath = Application.dataPath + "/Resources/Presentations/" + saveName;

			//Loads Presentation
			if (File.Exists (savePath + "\\" + saveName + ".pres")) {
				BinaryFormatter binary = new BinaryFormatter ();
				FileStream fStream = File.Open (savePath + "\\" + saveName + ".pres", FileMode.Open);
				presentation = (Presentation)binary.Deserialize (fStream);
				fStream.Close ();

				//Loads image
				imageRetriever.ApplySpriteFromPath (savePath + "\\" + saveName + ".jpg");
				//Ensures editor mode is in start state
				SetPointer (1);
			}
		} else {
			imageRetriever.ApplySpriteFromPath (filePath);
		}

	}
}
