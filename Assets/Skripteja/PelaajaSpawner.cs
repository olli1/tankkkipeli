using UnityEngine;
using System.Collections;

public class PelaajaSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	public int Lives;

	float reSpawnTimer;

	// Use this for initialization
	void Start () {

		SpawnPlayer ();
	
	}


	void SpawnPlayer(){
		Lives--;
		reSpawnTimer = 1;
		playerInstance =(GameObject)Instantiate(playerPrefab, transform.position, transform.rotation);
		Camera.main.gameObject.GetComponent<Kamera> ().player = playerInstance;

	}


	// Update is called once per frame
	void Update () {
	

		if (playerInstance == null && Lives>0) {
		



			reSpawnTimer -= Time.deltaTime;


			if (reSpawnTimer <= 0) {

				SpawnPlayer ();
			
			}
		
		
		}


	}

void OnGUI(){

		if (Lives > 0 || playerInstance != null) {
	
			GUI.Label (new Rect (0, 0, 100, 50), "Lives: " + Lives);

		} else {

			GUI.Label (new Rect (Screen.width/2, Screen.height/2, 100, 50), "GAME OVER, MAN!");
		
		
		}
	
	}






}
