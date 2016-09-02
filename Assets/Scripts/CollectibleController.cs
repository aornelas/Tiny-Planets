using UnityEngine;
using System.Collections;

public class CollectibleController : MonoBehaviour {

	public float speed = 1.0f;

	void Update()
	{
		transform.Rotate (new Vector3(0, 30, 0) * speed * Time.deltaTime);
		// TODO make slowly bounce
	}
}
