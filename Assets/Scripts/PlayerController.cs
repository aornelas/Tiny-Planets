using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private GameController gameController;

	private Vector3 initialPosition;

	void Start()
	{
		gameController = GetComponentInParent<GameController>();
		initialPosition = transform.localPosition;
	}

	public void ResetPlayer ()
	{
		transform.localPosition = initialPosition;
	}

	void OnTriggerEnter(Collider other) 
	{		
		if (other.tag == "Collectible")
		{
			gameController.PickUpCollectible(other.gameObject);
		}

		if (other.tag == "Portal")
		{
			gameController.TeleportToNextPlanet();
		}
	}

}
