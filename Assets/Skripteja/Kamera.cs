using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;
	public GameObject spawnipaikka;




	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

		spawnipaikka = GameObject.FindGameObjectWithTag ("Respawn");
	}




	void FixedUpdate(){

	if (player) {
			float PosX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
			float PosY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
	
	

			transform.position = new Vector3 (PosX, PosY, transform.position.z);
		}
	
	/*if (player == null) {




			float PosX = Mathf.SmoothDamp (transform.position.x, spawnipaikka.transform.position.x, ref velocity.x, smoothTimeX);
			float PosY = Mathf.SmoothDamp (transform.position.y, spawnipaikka.transform.position.y, ref velocity.y, smoothTimeY);
			
			
			
			transform.position = new Vector3 (PosX, PosY, transform.position.z);
	
		
		} */
	
	}






	// Update is called once per frame
	void Update () {


		if(player == null) {
			
			
			
			
			float PosX = Mathf.SmoothDamp (transform.position.x, spawnipaikka.transform.position.x, ref velocity.x, smoothTimeX);
			float PosY = Mathf.SmoothDamp (transform.position.y, spawnipaikka.transform.position.y, ref velocity.y, smoothTimeY);
			
			
			
			transform.position = new Vector3 (PosX, PosY, transform.position.z);
			
			
		} 




		

	
	}
}
