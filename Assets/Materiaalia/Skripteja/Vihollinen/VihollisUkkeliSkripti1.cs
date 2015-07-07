using UnityEngine;
using System.Collections;

public class VihollisUkkeliSkripti1 : MonoBehaviour {

	//Unity tutorial  2d space shooter part 5 -shooting and AI 32:30
	Transform player;

	public float rotaatio;




	//public Transform alku, loppu;
	//public bool huomattu = false;
	public bool inRange = false;

	public float range;

	Vector3 startPos;

	public float speed;
	public float returnSpeed;
	void Start () {



		//alkuperäinen sijainti tallennetaan tässä
		startPos = transform.position;


		if (rotaatio > 0) {
			transform.Rotate (Vector3.forward * rotaatio);
		}

	
	}


	void FixedUpdate(){
	

		//
	
	}





	// Update is called once per frame
	void Update () {

		if (!inRange) {
		
			GetComponent<EnemyFollowPath>();
		
		}



		//alue jossa pelaaja havaitaan 
		inRange = Physics2D.OverlapCircle (transform.position, range, 1 << LayerMask.NameToLayer ("Player"));













		if (inRange) {
			if(GetComponent<LiikeEteen>()){GetComponent<LiikeEteen>().spiidi=true;	}
	
		
			
			if (player == null) {
				//löydetään pelaaja
				GameObject go = GameObject.FindGameObjectWithTag ("Player");
		

				//tässä käännytään pelaaja päin
				

		
		

				if (go != null) {

					player = go.transform;
		
		
		
				}
		
			}


			if (player == null) {
				return;
			}
		
	
		



			//tässä käännytään pelaaja päin
			
			Vector3 dir = player.position - transform.position;
			dir.Normalize ();
			
			
			float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
			
			
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, zAngle), speed);





		}

		else{

			Vector3 suunta = startPos-transform.position;
			suunta.Normalize();

			float zKulma = Mathf.Atan2 (suunta.y, suunta.x) * Mathf.Rad2Deg - 90;

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, zKulma), speed);

		     


			if(GetComponent<LiikeEteen>()){
		
			GetComponent<LiikeEteen>().spiidi=false;
			}


			//transform.position = Vector3.zero;




			  


				
			   

			//transform.position = Vector3.MoveTowards(transform.position, startPos, returnSpeed * Time.deltaTime);
		}
		







		//Raycasting ();
		

	}


	//määritellään alue vihulaisen päälle
	void OnDrawGizmosSelected(){


		Gizmos.DrawSphere (transform.position, range);
	
	
	}












	//void Raycasting(){

		//Debug.DrawLine (alku.position, loppu.position, Color.green);

		//huomattu = Physics2D.Linecast (alku.position, loppu.position, 1 << LayerMask.NameToLayer ("Player"));


	//}










}
