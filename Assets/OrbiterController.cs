using UnityEngine;
using System.Collections;

public class OrbiterController : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{		
		other.GetComponent<AudioSource>().Play();
		if (other.tag == "Black Hole")
		{
			this.gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter(Collision col)
    {
    	col.gameObject.GetComponent<AudioSource>().Play();
    }
}
