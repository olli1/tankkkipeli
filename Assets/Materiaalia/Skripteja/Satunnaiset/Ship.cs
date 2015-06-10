using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {


	public AudioClip[] audioClip; //äänet taulukkoon



	public Rigidbody2D rb;
	public int speed;
	public float rotspeed;

	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;


	//bool kaynti;

	bool toiminnassa=false;

	// Use this for initialization
	void Start () {








		rb = GetComponent<Rigidbody2D> ();

	
	}



	// Update is called once per frame
	void Update () {





		if (toiminnassa) {




			if (Input.GetKeyUp (KeyCode.W) && GetComponent<AudioSource> ().isPlaying) {
			
				PlaySound (1);
				GetComponent<AudioSource> ().loop = true;
			
			}




			if (Input.GetKey (KeyCode.W)) {

				up = true;


				if (Input.GetKeyDown(KeyCode.W)){

					PlaySound (2);
					GetComponent<AudioSource> ().loop = true;

				}



			


			} else
				up = false;

	
		
			if (Input.GetKey (KeyCode.S)) {
				down = true;		
			} else
				down = false;
		
			if (Input.GetKey (KeyCode.D)) {
				right = true;	


			} else
				right = false;
		
			if (Input.GetKey (KeyCode.A)) {
				left = true;		
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
			rb.AddForce (transform.up * speed);


			     





				//transform.Rotate(new Vector2(0,speed * Time.deltaTime));
		} 

		if (down) {
			rb.AddForce(-transform.up * speed);

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


	void PlaySound(int clip,bool loop = false){
	
	
	 
		GetComponent<AudioSource> ().clip = audioClip [clip];
		if (loop) 
			GetComponent<AudioSource> ().loop = true;
		else
			GetComponent<AudioSource> ().loop = false;
		

		GetComponent<AudioSource>().Play();
	
	
	
	}










	}
