using UnityEngine;
using System.Collections;

public class PlanetOrienter : MonoBehaviour {

	public GameObject referencePoint;
	public Transform cameraFront;
	private bool orienting;

	void Start()
	{
		orienting = true;
	}

	void Update ()
	{
		OrientTowardsReference();
	}

	public void EnableOrienting ()
	{
		orienting = true;
		referencePoint.transform.position = cameraFront.transform.position;
		referencePoint.transform.rotation = cameraFront.transform.rotation;
	}

	public  void DisableOrienting ()
	{
		orienting = false;
	}

	private void OrientTowardsReference ()
	{
		if (orienting)
		{
			this.transform.LookAt(referencePoint.transform, referencePoint.transform.up);
		}
	}
}
