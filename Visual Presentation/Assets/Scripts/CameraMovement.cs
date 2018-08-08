using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Camera mainCamera;
	Register register;

	[SerializeField] float speed = 10f;
	[SerializeField] float rotationSpeed = 10f;
	[SerializeField] float zoomSpeed = 10f;
	Slide imageSlide;

	void Start ()
	{
		mainCamera = GetComponent<Camera> ();
		register = GetComponent<Register> ();
	}

	//Detects user inputs
	void Update() 
	{
		Move ();
		Rotate ();
		Zoom ();
		if (Input.GetKeyDown(KeyCode.O)){
			Relocate(imageSlide);
		}
		if (Input.GetKeyDown(KeyCode.P)){
			register.AddSlide();
		}
	}
		
	void Move () 
	{
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime * mainCamera.orthographicSize / 5f;
	}

	void Rotate ()
	{
		float inputR = Input.GetAxis("Fire2");
		Vector3 rotate = new Vector3 (0f, 0f, inputR * rotationSpeed * Time.deltaTime);
		transform.Rotate(rotate);
	}

	public void RotateButton (int button)
	{
		Vector3 rotate = new Vector3 (0f, 0f, button * rotationSpeed * Time.deltaTime);
		transform.Rotate (rotate);
	}

	void Zoom ()
	{
		float inputZ = Input.GetAxis("Fire1");
		mainCamera.orthographicSize += inputZ * zoomSpeed * Time.deltaTime;
		mainCamera.orthographicSize = Mathf.Clamp (mainCamera.orthographicSize, 0.1f, 100f);
	}

	public void Initialize (float size) 
	//Initialize camera's size to fit the image's size
	{
		imageSlide = new Slide(0, 0, 0, size);
		Relocate (imageSlide);
	}

	public void Relocate (Slide slide) 
	//Allows to jump from current position to requested slide
	{
		mainCamera.transform.position = new Vector3 (slide.Getx(), slide.Gety(), -10);
		mainCamera.transform.eulerAngles = new Vector3(0, 0, slide.GetRot());
		mainCamera.orthographicSize = slide.GetZoom();
	}

}
