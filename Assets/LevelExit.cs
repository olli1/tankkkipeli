using UnityEngine;
using System.Collections;

public class LevelExit : MonoBehaviour {

	public string Taso2;

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter2D(){
	
	
		Application.LoadLevel (Taso2);
	
	
	}




	// Update is called once per frame
	void Update () {
	
	}
}
