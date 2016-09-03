using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody planet;

	private Vector3 initialPosition;

	void Start()
	{
		initialPosition = transform.localPosition;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.V)) {
			PrintVelocity();
		}
	}

	public void ResetPlayer()
	{
		transform.localPosition = initialPosition;
	}

	void OnTriggerEnter(Collider other) 
	{		
		other.gameObject.GetComponent<AudioSource>().Play();
		other.transform.GetChild(0).gameObject.SetActive(false);
		other.enabled = false;
	}

	private void PrintVelocity()
	{
		Vector3 v = GetComponent<Rigidbody>().velocity;
		Vector3 vP = planet.velocity;
		Debug.Log(string.Format("({0} , {1}, {2})", Round(v.x - vP.x), Round(v.y - vP.y), Round(v.z - vP.z)));
	}

	private float Round(float f)
	{
		return Mathf.Round(f);
	}

}
