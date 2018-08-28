using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChange : MonoBehaviour {

	[SerializeField] Canvas canvasToActivate;
	[SerializeField] Canvas currentCanvas;

	[SerializeField] bool isThereInitialy;

	void Start () {
		if (isThereInitialy) {
			canvasToActivate.enabled = false;
		}
	}

	public void Escape () {
		canvasToActivate.enabled = true;
		currentCanvas.enabled = false;
	}
}
