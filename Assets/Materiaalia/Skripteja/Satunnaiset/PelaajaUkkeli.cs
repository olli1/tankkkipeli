using UnityEngine;
using System.Collections;

public class PelaajaUkkeli : MonoBehaviour {

	public Rigidbody2D rb2;
	public int speed;
	public float rotspeed;

	Animator anim;


	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;



void Start () {

		//anim = GetComponent<Animator> ();

rb2 = GetComponent<Rigidbody2D> ();

	
	}





	void Update () {




if (Input.GetKey (KeyCode.W)) 
			up = true;

	
	

 else
	 up = false;



if (Input.GetKey (KeyCode.S)) 
			down = true;

	else
		down = false;

		
			if (Input.GetKey (KeyCode.D)) 
				right = true;	
				
else
	right = false;

		
			if (Input.GetKey (KeyCode.A)) 
			left = true;
		else
			left = false;

}



	void FixedUpdate(){








		if (up) 
			rb2.AddForce (transform.up * speed);
				 

				
		if (down) 
			rb2.AddForce(-transform.up * speed);


		if (right) 
			transform.Rotate(new Vector3(0,0, -rotspeed * Time.deltaTime));
		
		    
		if (left) 
			transform.Rotate(new Vector3(0,0, rotspeed * Time.deltaTime));






	}


}
