using UnityEngine;
using System.Collections;

public class FauxGravityBody : MonoBehaviour {

	public FauxGravityAttractor attractor;

	void Update()
	{
		attractor.Attract(transform);
	}
}
