using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	public Transform referencePoint;

	void Start () {
		OrientTowardsReference();
	}

	void Update () {
		OrientTowardsReference();
	}

	/**
	 * Rotate the planet to face the reference point, which makes the planet rotate relative to the camera
	 */
	private void OrientTowardsReference() {
		this.transform.LookAt(referencePoint);
	}
}
