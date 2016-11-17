using UnityEngine;
using System.Collections;

public class GoogleCardboardController : MonoBehaviour {

	void Start ()
	{
	}

	void Update ()
	{
		this.gameObject.transform.Find("Canvas/cardboard button").gameObject.SetActive(!GvrViewer.Instance.VRModeEnabled);
		if (GvrViewer.Instance.Tilted)
		{
			DisableVR();
		}
	}

	public void DisableVR ()
	{
		GvrViewer.Instance.VRModeEnabled = false;
	}

	public void EnableVR ()
	{
		GvrViewer.Instance.VRModeEnabled = true;
	}
}
