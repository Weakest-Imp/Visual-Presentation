using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour {

	[SerializeField] Canvas canvas;

	void Start () {
		DisableCanvas ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvas.enabled = true;
		}
		if (Input.GetKeyDown (KeyCode.Backspace)) {
			canvas.enabled = true;
		}
	}

	public void DisableCanvas () {
		canvas.enabled = false;
	}

	public void PreviousScene () {
		GameManager.Instance.PreviousScene ();
	}
}
