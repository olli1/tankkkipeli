using UnityEngine;
using System.Collections;

public class Android : MonoBehaviour {

	public GameObject target;




	Vector3 lookat;
	float angle;
	Rigidbody2D rb;


	// Use this for initialization
	void Start () {


		rb = GetComponent<Rigidbody2D> ();

		lookat = target.transform.position - transform.position;
		angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

	
	}


	void Update () {

		lookat = target.transform.position - transform.position;
		angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

	}



	// Update is called once per frame
	void FixedUpdate () {


		rb.AddForce (transform.up * 50);
		rb.AddForce (transform.right * 50);


	
	}
}
