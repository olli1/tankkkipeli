using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public Rigidbody2D rb;
	public int speed;
	public float rotspeed;
	float timer = 0;
	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;

	bool shootside = false;

	Transform leftg;
	Transform rightg;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		leftg = transform.Find ("Left");
		rightg = transform.Find ("Right");
	
	}

	void shoot(){
		if (timer < Time.time) {
			if(shootside){
			GameObject tmp = Instantiate(Resources.Load ("beam"),leftg.position,leftg.rotation) as GameObject;
				bullet tmp2 = tmp.GetComponent<bullet>();
				tmp2.speed = 80;
				tmp2.taga = transform.tag;
				shootside = false;
				timer +=0.25f;


			}else {
				GameObject tmp = Instantiate(Resources.Load ("beam"),rightg.position,rightg.rotation) as GameObject;
				shootside = true;
				bullet tmp2 = tmp.GetComponent<bullet>();
				tmp2.speed = 80;
				tmp2.taga = transform.tag;
				timer +=0.25f;

			}
		}


	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			shoot ();
		}

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


		/*Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 lookat = transform.position - mouse;
		float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg +90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);*/

		if (up) {
			rb.AddForce(transform.up * speed);

			transform.Rotate(new Vector2(0,speed * Time.deltaTime));
		}

		if (down) {
			rb.AddForce(-transform.up * speed);

			transform.Rotate(new Vector2(0,-speed * Time.deltaTime));
		
		}

		if (right) {
			rb.AddForce (transform.right * speed);

			transform.Rotate(new Vector3(0,0, -rotspeed * Time.deltaTime));
		}
		    
		if (left) {
			rb.AddForce(-transform.right * speed);

			transform.Rotate(new Vector3(0,0, rotspeed * Time.deltaTime));


		}



	}

















	}
