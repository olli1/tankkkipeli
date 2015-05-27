using UnityEngine;
using System.Collections;

public class VihollisSkripti1 : MonoBehaviour {

	//Unity tutorial  2d space shooter part 5 .shooting and AI
	Transform player;

	public float speed;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player == null) {
		
		GameObject go =	GameObject.Find("PelaajaTankki 1");
		
		
		

		if (go != null) {

				player = go.transform;
		
		
		
			}
		
		}


		if (player == null)
			return;



		Vector3 dir = player.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;


		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, zAngle), speed);

		
		
		

	}
}
