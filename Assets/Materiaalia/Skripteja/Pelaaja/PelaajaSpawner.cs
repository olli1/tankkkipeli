using UnityEngine;
using System.Collections;

public class PelaajaSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	float loppuajastin =7;

	string MainMenu1 = "MAINMENU";

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
			loppuajastin-=Time.deltaTime;
			GUI.Label (new Rect(Screen.width * 0.5f, Screen.height * 0.10f, Screen.width * 0.5f, Screen.height * 0.1f),"BACK TO MENU IN: " + loppuajastin);

			if(loppuajastin<=0){
			
				Application.LoadLevel(MainMenu1);
			}
		
		}
	














		float pisteet = GameObject.Find ("Controlleri").GetComponent<Kontrolloi>().pisteet;
		GUI.Label (new Rect (0, 25, 100, 50), "Pisteet: " + pisteet);
	
	
	
	
	}






}
