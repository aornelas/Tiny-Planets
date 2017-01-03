using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private GameController gameController;

	private Vector3 initialPosition;
	public SteamVR_TrackedController leftController;
    public SteamVR_TrackedController rightController;

	void Start()
	{
		gameController = GetComponentInParent<GameController>();
		initialPosition = transform.localPosition;
		leftController.TriggerClicked += RightController_TriggerClicked;
        rightController.TriggerClicked += RightController_TriggerClicked;
	}

	void Update()
	{
		if (GvrViewer.Instance.Triggered) {
			ResetPlayer();
		}
	}

	private void RightController_TriggerClicked(object sender, ClickedEventArgs e)
    {
        ResetPlayer();
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
