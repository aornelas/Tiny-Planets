using UnityEngine;
using System.Collections;

public class OrbiterController : MonoBehaviour {

	void Update()
	{
	}

	void OnTriggerEnter(Collider other) 
	{		
		if (other.tag == "Black Hole")
		{
			this.gameObject.SetActive(false);
		}
	}
}
