using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public int platformIndex;
	private float pitchIncrease = 0.1f;

	void OnTriggerEnter(Collider other) 
	{		
		if (other.tag == "Ball")
		{
			GetComponent<AudioSource>().pitch = 1 + (platformIndex * pitchIncrease);
			GetComponent<AudioSource>().Play();
		}
	}
}
