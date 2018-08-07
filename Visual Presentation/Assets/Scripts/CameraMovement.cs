using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Camera mainCamera;

	[SerializeField] float speed = 10f;
	[SerializeField] float rotationSpeed = 10f;
	[SerializeField] float zoomSpeed = 10f;

	void Start ()
	{
		mainCamera = GetComponent<Camera> ();
	}

	void Update() 
	{
		Move ();
		Rotate ();
		Zoom ();
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

	void Zoom ()
	{
		float inputZ = Input.GetAxis("Fire1");
		mainCamera.orthographicSize += inputZ * zoomSpeed * Time.deltaTime;
		mainCamera.orthographicSize = Mathf.Clamp (mainCamera.orthographicSize, 0.1f, 100f);
	}

}
