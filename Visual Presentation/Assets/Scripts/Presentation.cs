using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Presentation : ScriptableObject 
{
	public List<Slide> slides;
	public Texture2D texture;

	public Presentation() 
	{
		this.slides = new List<Slide> ();
	}

}