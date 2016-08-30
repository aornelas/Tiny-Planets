using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 initialPosition;

	void Start()
	{
		initialPosition = transform.localPosition;
	}

	void Update()
	{
	}

	public void resetPlayer() {
		transform.localPosition = initialPosition;
	}

	private void OrientPlayer()
	{
		Transform myTransform = transform;
		Quaternion headDirection = GvrViewer.Instance.HeadPose.Orientation;
		transform.LookAt(headDirection * Vector3.forward);
	}
}
