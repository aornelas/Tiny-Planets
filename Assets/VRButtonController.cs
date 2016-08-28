using UnityEngine;
using System.Collections;

public class VRButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.SetActive(!GvrViewer.Instance.VRModeEnabled);
	}

	public void EnableVR() {
		GvrViewer.Instance.VRModeEnabled = true;
	}
}
