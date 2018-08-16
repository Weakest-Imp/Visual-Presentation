using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPointer : MonoBehaviour {

	Register register;
	Slider slider;

	// Use this for initialization
	void Start () {
		register = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Register> ();
		slider = this.GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		SetMax ();
		SetValue ();
	}

	public void MovePointer ()
	{
		int pointer = (int)slider.value + 1;
		register.SetPointer (pointer);
	}

	void SetMax ()
	{
		slider.maxValue = register.GetPointerRange () - 1;
	}
	void SetValue ()
	{
		slider.value = register.GetPointer ();
	}
}
