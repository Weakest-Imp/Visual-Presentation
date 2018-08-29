using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CameraMovementPresentation : MonoBehaviour {

	Presentation presentation;
	Camera mainCamera;
	string saveName;

	int pointer;
	[SerializeField] float timeToMove;
	float cooldown;

	void Start () {
		mainCamera = GetComponent<Camera> ();
		saveName = GameManager.Instance.saveName;
		LoadPresentation ();
		Relocate (GetSlide(pointer));
	}


	void Update () {
		if (cooldown < 0) {
			if (NextPressed ()) {
				NextSlide ();
			}
			if (PreviousPressed ()) {
				PreviousSlide ();
			}
		} else { cooldown -= Time.deltaTime;
		}
	}

	void LoadPresentation () {
		string savePath = Application.dataPath + "/Resources/Presentations/" + saveName;

		if (File.Exists (savePath + "\\" + saveName + ".pres")) {
			BinaryFormatter binary = new BinaryFormatter ();
			FileStream fStream = File.Open (savePath + "\\" + saveName + ".pres", FileMode.Open);
			presentation = (Presentation)binary.Deserialize (fStream);
			fStream.Close ();
			SetPointer (0);
		}
	}

	bool PointerInRange (int index)
	//Evaluates wether index is within the bounds of the presentation
	{
		return (index < presentation.slides.Count && index >= 0);
	}
	void SetPointer(int newPosition)
	//Different form editor's
	{
		if (PointerInRange(newPosition)) {
			pointer = newPosition;}
	}




	Slide GetSlide (int index)
	{
		return presentation.slides[index];
	}

	void Relocate (Slide slide) 
	//Allows to jump from current position to requested slide
	{
		mainCamera.transform.position = new Vector3 (slide.Getx(), slide.Gety(), -10);
		mainCamera.transform.eulerAngles = new Vector3(0, 0, slide.GetRot());
		mainCamera.orthographicSize = slide.GetZoom();
	}
//	IEnumerator SmoothRelocate (Slide slide) {
//
//	}

	//Functions to go forward in the presentation
	void PointerPlus ()
	{
		pointer++;
		if (!PointerInRange(pointer)) {
			pointer = 0;
		}
	}
	//Checks for inputs
	bool NextPressed ()	{
		bool nextPressed = false;
		nextPressed = (Input.GetAxisRaw ("Horizontal") == 1);
		return nextPressed;
	}
	void NextSlide () {
		PointerPlus ();
		Relocate (GetSlide (pointer));
		cooldown = timeToMove;
	}

	//Functions to go backward
	void PointerMinus ()
	{
		pointer--;
		if (!PointerInRange(pointer)) {
			pointer = presentation.slides.Count-1;
			if (pointer == -1) {pointer = 0;}
		}
	}
	//Checks for inputs
	bool PreviousPressed () {
		bool previousPressed = false;
		previousPressed = (Input.GetAxisRaw ("Horizontal") == -1);
		return previousPressed;
	}
	void PreviousSlide() {
		PointerMinus ();
		Relocate (GetSlide (pointer));
		cooldown = timeToMove;
	}
}
