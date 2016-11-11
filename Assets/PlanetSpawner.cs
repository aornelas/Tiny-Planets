using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour {

	public GameObject camera;
	public GameObject planetPrefab;
	public GravityAttractor blackHole;
//	public GravityAttractor blackHole1;
//	public GravityAttractor blackHole2;
	public float force = 100f;

	void Start()
	{
	
	}

	void Update()
	{
		if (GvrViewer.Instance.Triggered)
		{
			GetComponent<AudioSource>().Play();
			GameObject planet = (GameObject) Instantiate(planetPrefab, transform.position, new Quaternion());
			planet.GetComponent<GravityBody>().attractor = blackHole;
//			GravityAttractor[] attractors = new GravityAttractor[2];
//			attractors[0] = blackHole1;
//			attractors[1] = blackHole2;
//			planet.GetComponent<GravityBody>().attractors = attractors;
			planet.GetComponent<Rigidbody>().AddForce(camera.transform.forward * force, ForceMode.VelocityChange);
		}
	}
}
