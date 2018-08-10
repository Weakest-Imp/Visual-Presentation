using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteConfirm : MonoBehaviour {

	[SerializeField] GameObject firstClick;
	[SerializeField] float timeLimit;
	float time = 0f;

	void Update ()
	{
		time += Time.deltaTime;
		if (time > timeLimit) {NoClick ();}
	}


	public void NoClick ()
	{
		firstClick.SetActive (true);
		this.gameObject.SetActive (false);
	}

}
