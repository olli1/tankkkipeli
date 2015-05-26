using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public Rigidbody2D rb;
	public int speed;
	public float rotspeed;

	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();

	
	}



	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.W)) {
			up = true;		
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
		}
		else
			left = false;
		


	}










	void FixedUpdate(){




		if (up) {
			rb.AddForce(transform.up * speed);

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

















	}
