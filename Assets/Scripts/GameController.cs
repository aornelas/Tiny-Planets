﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject currentPlanet;
	public GameObject planetTarget;

	private int collectiblesNeeded = 3;
	private PlanetController planetController;
	private int collectedCount;
	private bool portalOpened;
	private bool teleporting;
	private bool arriving;
	private bool invokedSwapPlanet;
	private GravityAttractor gravityAttractor;
	private float teleportSpeed = 2.5f;

	void Start()
	{
		ResetPlanet();
		gravityAttractor = gameObject.GetComponentsInChildren<GravityAttractor>()[0];
	}

	void Update()
	{
		if (collectedCount >= collectiblesNeeded && !portalOpened)
		{
			Invoke("OpenPortal", 0.25f);
			portalOpened = true;
		}
		if (teleporting)
		{
			currentPlanet.transform.Translate(new Vector3(-50, -50, -50) * teleportSpeed * Time.deltaTime);
			if (!invokedSwapPlanet)
			{
				Invoke("SwapPlanet", 1.0f);
				invokedSwapPlanet = true;
			}
		}
		if (arriving)
		{
			Vector3 planetTargetPosition = planetTarget.transform.position;
			currentPlanet.transform.position = Vector3.MoveTowards(currentPlanet.transform.position, planetTargetPosition, teleportSpeed * 35 * Time.deltaTime);
			if (currentPlanet.transform.position == planetTargetPosition)
			{
				arriving = false;
			}
		}
	}

	public void PickUpCollectible(GameObject collectible) 
	{
		collectible.GetComponent<CollectibleController>().PickUp();
		collectedCount++;
	}

	public void TeleportToNextPlanet()
	{
		teleporting = true;
		FlipGravity();
		gameObject.transform.FindChild("Planets").GetComponent<AudioSource>().Play();
		Invoke("FlipGravity", 0.5f);
	}

	private void SwapPlanet()
	{
		teleporting = false;
		planetController.NextPlanet();
		currentPlanet = planetController.nextPlanet;
		currentPlanet.transform.Translate(new Vector3(10, 10, 10));	
		arriving = true;
		ResetPlanet();
	}

	private void ResetPlanet()
	{
		collectedCount = 0;
		portalOpened = false;
		invokedSwapPlanet = false;
		planetController = currentPlanet.GetComponent<PlanetController>();
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
