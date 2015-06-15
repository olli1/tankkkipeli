using UnityEngine;
using System.Collections;

public class Seuraa : MonoBehaviour {

	Transform player;

	float speed=4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


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








		Vector3 dir = player.position - transform.position;
		dir.Normalize ();
		
		
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		
		
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, zAngle), speed);



	
	}
}
