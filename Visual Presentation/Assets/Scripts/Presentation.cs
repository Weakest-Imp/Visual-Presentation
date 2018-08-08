using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Presentation : ScriptableObject 
{
	public List<Slide> slides;

	public Presentation() 
	{
		this.slides = new List<Slide> ();
	}
}