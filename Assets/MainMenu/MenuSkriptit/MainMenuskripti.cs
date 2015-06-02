using UnityEngine;
using System.Collections;

public class MainMenuskripti : MonoBehaviour {

	public Texture taustaTextuuri;

	public string Level1;


	public GUIStyle Random1; //TOISEN TAVAN PAINIKKEILLE

	public float painikkeen_SijaintiY = 0.5f;
	public float painike_SijaintiX = 0.375f;

	void OnGUI(){
	//saadaan taustakuva näkyviin

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), taustaTextuuri);

	//näyttää painikkeet

		//GUI.Label (new Rect (Screen.width * 0.25f, Screen.height * 0.10f, Screen.width * 0.5f, Screen.height * 0.1f), "PELI");




//ENSIMMÄINEN TAPA		                         //painikkeen sijainti tässä                 //Painikkeen koko määritys//koko vaikuttaa sijaintiin//painike teksti

		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.20f, Screen.width * 0.5f, Screen.height * 0.1f), "PLAY")) {
		
			print ("Klikattu");

			Application.LoadLevel(Level1);
				


		}


		if (GUI.Button (new Rect (Screen.width * painike_SijaintiX, Screen.height * painikkeen_SijaintiY, Screen.width * 0.25f, Screen.height * 0.1f), "QUIT")) {
			


			Application.Quit();


			
		}




    //TOINEN TAPA PAINIKKEILLE
																														//TEXTUURI	
		/*if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.20f, Screen.width * 0.5f, Screen.height * 0.1f),"",Random1)) {
			
			print ("Klikattu");
			
		}
		
		



		if (GUI.Button (new Rect (Screen.width * painike_SijaintiX, Screen.height * painikkeen_SijaintiY, Screen.width * 0.25f, Screen.height * 0.1f), "QUIT")) {
			
			print ("Klikattu");
			
		}*/
	
	
	}










}
