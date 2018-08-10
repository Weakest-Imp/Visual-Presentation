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

	[SerializeField]float dragSpeed_x = 4.5f;
	[SerializeField]float dragSpeed_y = 2;
	private Vector3 oldMousePosition;
	bool leftRotate = false;
	bool rightRotate = false;
	bool zoomIn = false;
	bool zoomOut = false;

	void Start ()
	{
		mainCamera = GetComponent<Camera> ();
		register = GetComponent<Register> ();
	}

	//Detects user inputs
	void Update() 
	{
		//Keyboard controls
		Move ();
		Rotate ();
		Zoom ();
		if (Input.GetKeyDown(KeyCode.O)){
			Relocate(imageSlide);
		}
		if (Input.GetKeyDown(KeyCode.P)){
			register.AddSlide();
		}

		//Mouse controls
		DragNMove ();
		if (leftRotate) {
			RotateButton (1);
		}
		if (rightRotate) {
			RotateButton (-1);
		}
		if (zoomIn) {
			ZoomButon (-1);
		}
		if (zoomOut) {
			ZoomButon (1);
		}
	}
		
	void Move () 
	{
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime * mainCamera.orthographicSize / 5f;
	}

	void DragNMove ()
	//Found online
	{
		if (Input.GetMouseButtonDown(0))
		{
			oldMousePosition = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton(0)) return;

		Vector3 newMousePosition = Input.mousePosition;

		Vector3 pos = Camera.main.ScreenToViewportPoint(newMousePosition - oldMousePosition);
		float move_x = -1 * pos.x * dragSpeed_x * mainCamera.orthographicSize;
		float move_y = -1 * pos.y * dragSpeed_y * mainCamera.orthographicSize;
		Vector3 move = new Vector3(move_x, move_y, 0);

		transform.Translate(move, Space.World);  

		oldMousePosition = newMousePosition;
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

	public void PressButtonLeft (bool pressed)
	{
		leftRotate = pressed;
	}
	public void PressButtonRight (bool pressed)
	{
		rightRotate = pressed;
	}

	void Zoom ()
	{
		float inputZ = Input.GetAxis("Fire1");
		mainCamera.orthographicSize += inputZ * zoomSpeed * Time.deltaTime;
		mainCamera.orthographicSize = Mathf.Clamp (mainCamera.orthographicSize, 0.1f, 100f);
	}

	public void ZoomButon (int button)
	{
		mainCamera.orthographicSize += button * zoomSpeed * Time.deltaTime;
		mainCamera.orthographicSize = Mathf.Clamp (mainCamera.orthographicSize, 0.1f, 100f);
	}

	public void PressButtonZoom (bool pressed)
	{
		zoomIn = pressed;
	}
	public void PressButtonDezoom (bool pressed)
	{
		zoomOut = pressed;
	}

	public void Initialize (float size) 
	//Initialize camera's size to fit the image's size a first time
	{
		imageSlide = new Slide(0, 0, 0, size);
		Relocate (imageSlide);
	}
	public void ReInitialize () 
	//Returns the camera to the full picture
	{
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
