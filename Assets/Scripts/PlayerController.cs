using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody planet;

	private Vector3 initialPosition;

	void Start()
	{
		initialPosition = transform.localPosition;
	}

	public void ResetPlayer()
	{
		transform.localPosition = initialPosition;
	}

	void OnTriggerEnter(Collider other) 
	{		
		other.gameObject.GetComponent<CollectibleController>().PickUp();
	}

}
