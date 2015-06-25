using UnityEngine;
using System.Collections;

public class OvenLiike : MonoBehaviour {

	public float maxSpeed = 8f;

	public bool suunta;

	public bool spiidi2 = true;



	float ajastin = 3;

	// Update is called once per frame

	void Start(){
	
	

	
	
	
	}



	void Update (){


		if (suunta) {

			if (spiidi2) {
				Vector3 pos = transform.position;

				Vector3 velocity = new Vector3 (-maxSpeed * Time.deltaTime, 0, 0);



				pos += transform.rotation * velocity;

		

				transform.position = pos;

				ajastin -= Time.deltaTime;

				if (ajastin <= 0)
					spiidi2 = false;







			}





		





		}




		else
			
			
		if (spiidi2) {
			Vector3 pos = transform.position;
			
			Vector3 velocity = new Vector3 (maxSpeed * Time.deltaTime, 0, 0);
			
			
			
			pos += transform.rotation * velocity;
			
			
			
			transform.position = pos;
			
			ajastin -= Time.deltaTime;
			
			if (ajastin <= 0)
				spiidi2 = false;
			
			
			
			
			
			
			
		}




	}











	





} 

