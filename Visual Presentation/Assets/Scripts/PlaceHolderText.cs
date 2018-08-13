using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceHolderText : MonoBehaviour {

	Register register;
	InputField field;
	Text placeHolderText;

	// Use this for initialization
	void Start () {
		register = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Register> ();
		placeHolderText = this.GetComponent<InputField> ().placeholder.GetComponent<Text> ();
		field = this.GetComponent<InputField> ();
		UpdateText ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)){
			UpdateText();
		}
	}

	public void UpdateText () {
		if (register.IsEmpty ()) {	
			placeHolderText.text = "No slide";
		} else {
			int pointer = register.GetPointer ();
			placeHolderText.text = (pointer + 1).ToString ();
		}
	}

	public void Clean () 
	{
		field.text = "";
	}
}
