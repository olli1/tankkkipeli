using UnityEngine;
using System.Collections;

public class EteenLiike : MonoBehaviour {

	public float maxSpeed = 8f;

	public bool spiidi = true;

	// Update is called once per frame
	void Update () {
	

		if (spiidi) {
			Vector3 pos = transform.position;

			Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime, 0);

			scaletus();

			pos += transform.rotation * velocity;

			transform.position = pos;
		}





	}



	void scaletus(){
	
		transform.localScale += new Vector3(0.1f, 0.1f, 0)*Time.deltaTime*4f;


	}






} 

