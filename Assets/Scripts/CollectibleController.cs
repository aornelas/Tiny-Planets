using UnityEngine;
using System.Collections;

public class CollectibleController : MonoBehaviour {

	public float speed = 1.0f;

	private GameObject pickUpFX;

	void Start()
	{
		pickUpFX = transform.FindChild("MagicEffect1").gameObject;
	}

	void Update()
	{
		transform.Rotate (new Vector3(0, 30, 0) * speed * Time.deltaTime);
		// TODO make slowly bounce
	}

	public void PickUp()
	{
		GetComponent<AudioSource>().Play();
		transform.FindChild("Diamond").gameObject.SetActive(false);
		transform.FindChild("GodRays").gameObject.SetActive(false);
		transform.FindChild("MagicEffect1").GetComponent<ParticleSystem>().Play();
		Invoke("DisablePickUpFx", 1);
		this.enabled = false;
	}

	private void DisablePickUpFx()
	{
		pickUpFX.SetActive(false);
	}
}
