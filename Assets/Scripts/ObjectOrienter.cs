using UnityEngine;
using System.Collections;

public class ObjectOrienter : MonoBehaviour {

	public Transform referencePoint;

	void Update()
	{
		OrientTowardsReference();
	}

	void OnEnable()
	{
		OrientTowardsReference();
	}

	private void OrientTowardsReference()
	{
		this.transform.LookAt(referencePoint);
	}
}
