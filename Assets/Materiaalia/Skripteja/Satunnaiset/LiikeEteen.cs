using UnityEngine;
using System.Collections;

public class LiikeEteen : MonoBehaviour {

	public float maxSpeed = 8f;

	public bool spiidi = true;

	// Update is called once per frame
	void Update () {
	

		if (spiidi) {
			Vector3 pos = transform.position;

			Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime, 0);



			pos += transform.rotation * velocity;

			transform.position = pos;
		}





	}









} 

