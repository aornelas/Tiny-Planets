using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour {

	public float speed = 10f;

	void Update()
	{
		transform.Rotate (new Vector3(0, 30, 0) * speed * Time.deltaTime);
	}
}
