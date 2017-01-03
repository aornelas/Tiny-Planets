using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	public int checkpointIndex;
	private float pitchIncrease = 0.1f;

	void OnTriggerEnter (Collider other) 
	{		
		if (other.tag == "Ball")
		{
			GetComponent<AudioSource>().pitch = 1 + (checkpointIndex * pitchIncrease);
			GetComponent<AudioSource>().Play();
		}
	}
}
