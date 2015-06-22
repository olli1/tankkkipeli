using UnityEngine;
using System.Collections;


public class Kontrolloi : MonoBehaviour {
	public GameObject playerPrefab;
	public float pisteet = 0;
	public GameObject ExitKyltti;

	public GUIStyle healthBarGui;



	int healtti; 






		
		
		
		
	
	








	public bool pause = false;

	// Use this for initialization
	void Start () {



		//healtti = GameObject.FindGameObjectWithTag ("Player").GetComponent<KolariVahinko> ().health;



	
	}












	public void lisaa(float p){
		pisteet += p;
	}
	// Update is called once per frame
	void Update () {


		healtti = GameObject.FindGameObjectWithTag ("Player").GetComponent<KolariVahinko> ().health;


	
		if (Input.GetKeyDown (KeyCode.P)) {

			pause = togglePause();
		}



		
		if(!(GameObject.FindGameObjectWithTag("Enemy"))){
		
		
			ExitKyltti.SetActive(true);
		

	
	}
}

	void OnGUI(){

		float guihp = (100/healtti);
		GUI.Box(new Rect (100, 5, (Screen.width / 3 )*10/ guihp, 20), "" + healtti,healthBarGui);
		Debug.Log (guihp);












		if (pause) {
		
		
			GUI.Label(new Rect (Screen.width * 0.50f, Screen.height * 0.10f, Screen.width * 0.5f, Screen.height * 0.1f), "PAUSE");
			    if(GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.20f, Screen.width * 0.5f, Screen.height * 0.1f), "CLICK TO CONTINUE"))
				pause = togglePause();

		
		}
	
	
	
	
	
	
	}



	public bool togglePause(){

		if (Time.timeScale == 0f) {
		
		
			Time.timeScale = 1f;
			return(false);
		
		
		} else {
		
			Time.timeScale = 0f;
			return(true);
		
		
		}
	
	
	
	
	
	}




















	
	
	







}