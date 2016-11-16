using UnityEngine;
using System.Collections;

public class SphereMazeController : MonoBehaviour {

	public PlanetOrienter orienter;

	void Update()
	{
		if (Input.GetMouseButton(0)) {
			orienter.DisableOrienting();
		}
		if (Input.GetMouseButtonUp(0)){
			orienter.EnableOrienting();
		}
	}
}
