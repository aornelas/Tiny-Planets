using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {

	public float gravity = -70f;

	public void Attract(Transform body) {
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 bodyUp = body.up;

		body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

		Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
		// TODO: Break up so Tiny Planets and Black Hole can both use this class
//		body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
	}
}
