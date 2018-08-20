using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represents a "slide" of the presentation, by its coordinates
[System.Serializable]
public class Slide {

	float pos_x;
	float pos_y;
	float rot_z;
	float zoom;

	public Slide (float pos_x, float pos_y, float rot_z, float zoom)
	{
		this.pos_x = pos_x;
		this.pos_y = pos_y;
		this.rot_z = rot_z;
		this.zoom = zoom;
	}

	public float Getx ()
	{
		return pos_x;
	}
	public float Gety ()
	{
		return pos_y;
	}
	public float GetRot ()
	{
		return rot_z;
	}
	public float GetZoom ()
	{
		return zoom;
	}
}
