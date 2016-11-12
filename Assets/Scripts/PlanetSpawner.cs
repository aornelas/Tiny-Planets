using UnityEngine;
using System.Collections;

public class PlanetSpawner : MonoBehaviour {

	public GameObject camera;
	public GameObject planetPrefab;
	public GravityAttractor blackHole;
//	public GravityAttractor blackHole1;
//	public GravityAttractor blackHole2;
	public float thrust = 100f;
	public float torque = 25000f;

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
			planet.GetComponent<Rigidbody>().AddForce(camera.transform.forward * thrust, ForceMode.VelocityChange);
			planet.GetComponent<Rigidbody>().AddTorque(transform.up * torque);
		}
	}
}
