using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Presentation
{
	public List<Slide> slides;

	public Presentation() 
	{
		this.slides = new List<Slide> ();
	}

}