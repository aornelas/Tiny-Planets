using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 initialPosition;

	// TODO: Move to GameController
	public GameObject currentPlanet;
	private PlanetController planetController;
	private int collectedCount;
	private bool portalOpened;


	void Start()
	{
		initialPosition = transform.localPosition;
		ResetPlanet();
	}

	void Update () {
		if (collectedCount >= 3 && !portalOpened)
		{
			Invoke("OpenPortal", 0.25f);
			portalOpened = true;
		}
	}

	public void ResetPlayer ()
	{
		transform.localPosition = initialPosition;
	}

	void OnTriggerEnter(Collider other) 
	{		
		if (other.tag == "Collectible")
		{
			other.gameObject.GetComponent<CollectibleController>().PickUp();
			collectedCount++;
		}

		if (other.tag == "Portal")
		{
			planetController.NextPlanet();
			currentPlanet = planetController.nextPlanet;
			ResetPlanet();
		}
	}

	private void OpenPortal()
	{
		planetController.portal.SetActive(true);
		GetComponent<AudioSource>().Play();
	}

	private void ResetPlanet()
	{
		collectedCount = 0;
		portalOpened = false;
		planetController = currentPlanet.GetComponent<PlanetController>();
	}

}
