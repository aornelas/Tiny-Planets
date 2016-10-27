using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject currentPlanet;
	private PlanetController planetController;
	private int collectedCount;
	private bool portalOpened;

	void Start()
	{
		ResetPlanet();
	}

	void Update()
	{
		if (collectedCount >= 3 && !portalOpened)
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
	}

	private void ResetPlanet()
	{
		collectedCount = 0;
		portalOpened = false;
		planetController = currentPlanet.GetComponent<PlanetController>();
	}

	private void OpenPortal()
	{
		planetController.portal.SetActive(true);
		GetComponent<AudioSource>().Play();
	}
}
