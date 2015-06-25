using UnityEngine;
using System.Collections;

public class PelaajaUkkeli : MonoBehaviour {

	public Rigidbody2D rb2;
	public int speed;
	public float rotspeed;
	float playerspeedi;

	Animator anim;
	public Animator anim2;





	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;



void Start () {

		GameObject Torso = GameObject.Find("UkkeliTorso");

		Animator anim2 = Torso.GetComponent<Animator> ();






		anim = GetComponent<Animator> ();

rb2 = GetComponent<Rigidbody2D> ();

	
	}





	void Update () {





if (Input.GetKey (KeyCode.W)) { 
			up = true;
			anim2.SetBool("heilu",true);
			anim.SetBool ("liiku", true);
		} else {
			up = false;
			anim.SetBool ("liiku", false);
			anim2.SetBool("heilu",false);
		}


if (Input.GetKey (KeyCode.S)) { 
			down = true;
			anim2.SetBool("heilu",true);
			anim.SetBool ("liiku", true);
		} else {
			down = false;
			//anim.SetBool ("liiku", false);
		}

		
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
