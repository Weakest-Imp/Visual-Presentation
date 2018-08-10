using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoClickScript : MonoBehaviour {

	[SerializeField] GameObject confirm;

	public void FirstClick ()
	{
		confirm.SetActive (true);
		this.gameObject.SetActive (false);
	}

}
