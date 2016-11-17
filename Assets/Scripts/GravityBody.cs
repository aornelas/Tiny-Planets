using UnityEngine;
using System.Collections;

public class GravityBody : MonoBehaviour {

//	public GravityAttractor attractor;
	public GravityAttractor[] attractors;

	void Update ()
	{
		if (attractors != null) {
			foreach (GravityAttractor a in attractors) {
				a.Attract (transform);
			}
		}
//		attractor.Attract(transform);
	}
}
