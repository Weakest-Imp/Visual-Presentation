using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPositionField : MonoBehaviour {

	[SerializeField] GameObject confirm;
	InputField field;

	//reverts the button order and clean the text for next use
	public void OnDone ()
	{
		confirm.SetActive (true);

		field = this.GetComponent<InputField> ();
		field.text = "";
		this.gameObject.SetActive (false);
	}

}
