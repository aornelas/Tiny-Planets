using UnityEngine;
using System.Collections;

public class SphereMazeController : MonoBehaviour {

	public PlanetOrienter orienter;

	void Update()
	{
//		if (GvrViewer.Instance.Triggered) {
		if (Input.GetMouseButton(0)) {
			orienter.DisableOrienting();
		} else {
		// Fix
			orienter.EnableOrienting();
		}
	}
}
