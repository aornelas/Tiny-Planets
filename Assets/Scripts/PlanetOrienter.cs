using UnityEngine;
using System.Collections;

public class PlanetOrienter : MonoBehaviour {

	public Transform referencePoint;
	private bool orienting;

	void Start()
	{
		orienting = true;
	}

	void Update ()
	{
		OrientTowardsReference();
	}

	// TODO: do we really need this one?
	void OnEnable ()
	{
//		OrientTowardsReference();
	}

	public void EnableOrienting ()
	{
		orienting = true;
	}

	public  void DisableOrienting ()
	{
		orienting = false;
	}

	private void OrientTowardsReference ()
	{
		if (orienting)
		{
			this.transform.LookAt(referencePoint);
		}
	}
}
