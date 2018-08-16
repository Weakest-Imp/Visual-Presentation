using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementDiet : MonoBehaviour {

	Camera miniCamera;
	Register register;

	//Identifies the mini camera position regarding the pointer
	[SerializeField] int miniCamPos;
	int pointer;
	int previousPointer;
	bool camOn;

	// Use this for initialization
	void Start () {
		miniCamera = GetComponent<Camera> ();
		register = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Register> ();
		pointer = register.GetPointer ();
		previousPointer = pointer;
		camOn = false;
	}

	void Update()
	{
		pointer = register.GetPointer ();
		if (pointer != previousPointer) {
			if (register.PointerInRange (pointer + miniCamPos)) {
				camOn = true;
				TurnOnOff (camOn);
				Relocate (register.GetSlide (pointer + miniCamPos));
			} else {
				camOn = false;
				TurnOnOff (camOn);
			}
		}
		if (camOn== false) {
			if (register.PointerInRange (pointer + miniCamPos)) {
				camOn = true;
				TurnOnOff (camOn);
				Relocate (register.GetSlide (pointer + miniCamPos));
			}
		}
		previousPointer = pointer;
	}

	public void Relocate (Slide slide) 
	//Allows to jump from current position to requested slide
	{
		miniCamera.transform.position = new Vector3 (slide.Getx(), slide.Gety(), -10);
		miniCamera.transform.eulerAngles = new Vector3(0, 0, slide.GetRot());
		miniCamera.orthographicSize = slide.GetZoom();
	}

	void TurnOnOff (bool camOn)
	{
		int z;
		if (camOn) {
			z = -9;
		} else {
			z = 1;
		}
		float x = this.gameObject.transform.position.x;
		float y = this.gameObject.transform.position.y;

		this.gameObject.transform.position = new Vector3 (x, y, z); 
	}
}
