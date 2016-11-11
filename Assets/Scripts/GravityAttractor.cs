using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {

	public float gravity = -70f;
	public bool rotateBodies = true;

	public void Attract(Transform body) {
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 bodyUp = body.up;

		body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

		Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
		if (rotateBodies) {
			body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
		}
	}
}
