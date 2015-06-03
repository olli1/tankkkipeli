using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	Rigidbody2D rb;
	public int speed = 10;
	public int damage = 5;
	public string taga;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 5);
	}

	void OnTriggerEnter2D()
		
	{
		Debug.Log ("triggeri");//testi
		
		
		

		
		
		
		gameObject.layer = 10; //vaihta layeria
		
	}

	// Update is called once per frame
	void Update () {
	
	}



	void FixedUpdate(){

		rb.AddForce (transform.up * speed);
	}
}
