using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject currentPlanet;
	private int collectiblesNeeded = 3;
	private PlanetController planetController;
	private int collectedCount;
	private bool portalOpened;
	private FauxGravityAttractor gravityAttractor;

	void Start()
	{
		ResetPlanet();
		gravityAttractor = gameObject.GetComponentsInChildren<FauxGravityAttractor>()[0];
	}

	void Update()
	{
		if (collectedCount >= collectiblesNeeded && !portalOpened)
		{
			Invoke("OpenPortal", 0.25f);
			portalOpened = true;
		}
	}

	public void PickUpCollectible(GameObject collectible) 
	{
		collectible.GetComponent<CollectibleController>().PickUp();
		collectedCount++;
	}

	public void TeleportToNextPlanet()
	{
		planetController.NextPlanet();
		currentPlanet = planetController.nextPlanet;
		ResetPlanet();
		FlipGravity();
		Invoke("ResetPlayer", 0.25f);
	}

	private void ResetPlanet()
	{
		collectedCount = 0;
		portalOpened = false;
		planetController = currentPlanet.GetComponent<PlanetController>();
	}

	private void ResetPlayer()
	{
		FlipGravity();
		gameObject.GetComponentsInChildren<PlayerController>()[0].ResetPlayer();
	}

	private void FlipGravity()
	{
		gravityAttractor.gravity = gravityAttractor.gravity * -1;
	}

	private void OpenPortal()
	{
		planetController.portal.SetActive(true);
		GetComponent<AudioSource>().Play();
	}
}
