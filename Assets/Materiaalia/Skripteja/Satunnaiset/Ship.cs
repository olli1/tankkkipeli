using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public GameObject bulletPrefab;
	public AudioClip[] audioClip; //äänet taulukkoon

	int ammuslayer;

	public Rigidbody2D rb;
	public int speed;
	public float rotspeed;

	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;




	float jaahyAjastin2 = 0;
	public float viive2;



	AudioSource[] aanet;
	//public bool kaynti=false;

	bool toiminnassa=false;

	// Use this for initialization
	void Start () {

		ampuu2 = transform.Find ("Ampupiste2");

		aanet = GetComponents<AudioSource> ();

		ammuslayer = gameObject.layer;






		rb = GetComponent<Rigidbody2D> ();

	
	}

	Transform ampuu2;


	bool sammuu = false;
	// Update is called once per frame
	void Update () {



		jaahyAjastin2 -= Time.deltaTime;
		
		if (Input.GetMouseButton (1)&& jaahyAjastin2 <= 0) {
			



			jaahyAjastin2 = viive2;
			
			GameObject bulletGO2 = (GameObject)Instantiate (bulletPrefab, ampuu2.position, ampuu2.rotation);//ammuksen lähtöpaikan määritys ja ammuksen luonti kun ammutaan
			
			bulletPrefab.GetComponent<ammus>().health = bulletPrefab.GetComponent<ammus>().health =0.5f;



			bulletGO2.transform.localScale = new Vector3(0.1f,0.1f,0);



			bulletGO2.layer = ammuslayer;
			
			
		}


		if (Input.GetMouseButtonDown (1)) {
			PlaySound (4, true, 2);

		} 
		if(Input.GetMouseButtonUp(1)){
			StopSound(2);
			bulletPrefab.GetComponent<ammus>().health = bulletPrefab.GetComponent<ammus>().health =1;
		}

		
		










		if (toiminnassa) {

			if(!up&&!down && GetComponent<AudioSource>().pitch >1){
			
			GetComponent<AudioSource> ().pitch = GetComponent<AudioSource> ().pitch - Time.deltaTime * 0.25f;
			}
				



		/*	if (Input.GetKeyUp (KeyCode.W) && GetComponent<AudioSource> ().isPlaying) {
				Debug.Log (rb.velocity.y);

				delay-=Time.deltaTime;
				
				
				if(delay<=0)	
					StopSound (1);}

			
			}*/







			if(GetComponent<AudioSource> ().pitch <= 1  && sammuu == true && !up&&!down&&!right&&!left){
				
				sammuu =false;



				
				PlaySound (1, true);
				StopSound (1);
			}




			
		
	

	




			if (Input.GetKey (KeyCode.W)) {

				up = true;

				sammuu = true;

				if (Input.GetKeyDown(KeyCode.W)){

					PlaySound (2);
					GetComponent<AudioSource> ().loop = true;

					PlaySound (3,true,1);



				}



			


			} else
				up = false;

	
		
			if (Input.GetKey (KeyCode.S)) {
			
				down = true;

				sammuu = true;

				if (Input.GetKeyDown(KeyCode.S)){
					
					PlaySound (2);
					GetComponent<AudioSource> ().loop = true;
					
					PlaySound (3,true,1);


					
					
					
				}







			} else
				down = false;
		
			if (Input.GetKey (KeyCode.D)) {
				right = true;	
				sammuu=true;
				if (Input.GetKeyDown(KeyCode.D)){

					PlaySound (3,true,1);
				
				}




			} else
				right = false;

		
			if (Input.GetKey (KeyCode.A)) {
				left = true;
				sammuu=true;
				if (Input.GetKeyDown(KeyCode.A)){
					
					PlaySound (3,true,1);
					
				}




			} else
				left = false;


		}


		if (Input.GetKey (KeyCode.I)) {
			
			
			
			if(kaynnissa <2){
				PlaySound (0);

				toiminnassa=true;	
				
				kaynnissa = 2;






				
			}

		}

	
				
			



		
		 


		//Debug.Log (kaynnissa);

 if(kaynnissa == 2 && !GetComponent<AudioSource>().isPlaying) {

			PlaySound(1,true);

			kaynnissa = 3;



		}



  }


	int kaynnissa = 0;









	void FixedUpdate(){




		if (up) {
			//if(rb.velocity.y <=8f){

			rb.AddForce (transform.up * speed);
				
			GetComponent<AudioSource> ().pitch = GetComponent<AudioSource> ().pitch + Time.deltaTime * 0.17f;

		
				
			
				
			


			if (GetComponent<AudioSource> ().pitch >= 1.40f) {

				GetComponent<AudioSource> ().pitch = 1.40f;

			


			
			
			
			
			}





	
		} 

				

				
			
			
			


			     





				//transform.Rotate(new Vector2(0,speed * Time.deltaTime));


		if (down) {
			rb.AddForce(-transform.up * speed);

			GetComponent<AudioSource> ().pitch = GetComponent<AudioSource> ().pitch + Time.deltaTime * 0.20f;


			if (GetComponent<AudioSource> ().pitch >= 1.40f) {
				
				GetComponent<AudioSource> ().pitch = 1.40f;
				
				
				
				
				
				
				
				
			}


			//transform.Rotate(new Vector2(0,-speed * Time.deltaTime));
		
		}

		if (right) {
			//rb.AddForce (transform.right * speed);

			transform.Rotate(new Vector3(0,0, -rotspeed * Time.deltaTime));
		}
		    
		if (left) {
			//rb.AddForce(-transform.right * speed);

			transform.Rotate(new Vector3(0,0, rotspeed * Time.deltaTime));


		}



	}


	void PlaySound(int clip,bool loop = false,int source = 0){
	
		aanet [source].clip = audioClip [clip];
	 
		//GetComponent<AudioSource> ().clip = audioClip [clip];
		if (loop) 
			aanet [source].loop = true;
		else
			aanet [source].loop = false;
		

		aanet[source].Play();
	
	
	
	}
	void StopSound(int source = 0){
		aanet [source].Stop ();
	}










	}
