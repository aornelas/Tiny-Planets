using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	public Transform referencePoint;
	public GameObject nextPlanet;
	public GameObject vrButton;
	public float speed = 0.1f;

	void Start() {
	}

	void OnEnable() {
		OrientTowardsReference();
	}

	void Update()
	{
		HandleTouch();
		OrientTowardsReference();
		if (GvrViewer.Instance.Tilted)
		{
			DisableVR();
		}
		if (GvrViewer.Instance.Triggered)
		{
			NextPlanet();
		}
	}

	private void OrientTowardsReference()
	{
		this.transform.LookAt(referencePoint);
	}

	private void DisableVR()
	{
		GvrViewer.Instance.VRModeEnabled = false;
		vrButton.SetActive(true);
	}

	private void NextPlanet()
	{
		this.gameObject.SetActive(false);
		nextPlanet.SetActive(true);
	}

	private void HandleTouch()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			// TODO: Fix me
			transform.Rotate (-touchDeltaPosition.y * speed, -touchDeltaPosition.x * speed, 0);
		}
	}
}
