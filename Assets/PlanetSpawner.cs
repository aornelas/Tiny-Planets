using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour {

	public GameObject camera;
	public GameObject planetPrefab;
	public GravityAttractor blackHole;

	void Start()
	{
	
	}

	void Update()
	{
		if (GvrViewer.Instance.Triggered)
		{
			GameObject planet = (GameObject) Instantiate(planetPrefab, transform.position, new Quaternion());
			planet.GetComponent<GravityBody>().attractor = blackHole;
			planet.GetComponent<Rigidbody>().AddForce(camera.transform.forward*100f, ForceMode.VelocityChange);
		}
	}
}
