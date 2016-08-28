using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	public Transform referencePoint;
	public GameObject nextPlanet;

	void Start () {
		Debug.Log("Started " + this.name);
		OrientTowardsReference();
	}

	void Update () {
		OrientTowardsReference();
		if (GvrViewer.Instance.Triggered) {
			Debug.Log("Triggered " + this.name);
			this.gameObject.SetActive(false);
			nextPlanet.SetActive(true);
		}
	}

	/**
	 * Rotate the planet to face the reference point, which makes the planet rotate relative to the camera
	 */
	public void OrientTowardsReference() {
		this.transform.LookAt(referencePoint);
	}
}
