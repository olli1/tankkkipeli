using UnityEngine;
using System.Collections;

public class LevelExit : MonoBehaviour {

	public string Taso;

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter2D(){
	
	
		Application.LoadLevel (Taso);
	
	
	}




	// Update is called once per frame
	void Update () {
	








	}
}
