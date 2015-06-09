using UnityEngine;
using System.Collections;

public class Kontrolloi : MonoBehaviour {
	public float pisteet = 0;
	public GameObject ExitKyltti;
	// Use this for initialization
	void Start () {
	
	}
	public void lisaa(float p){
		pisteet += p;
	}
	// Update is called once per frame
	void Update () {
	

		if(!(GameObject.FindGameObjectWithTag("Enemy"))){
		
		
			ExitKyltti.SetActive(true);
		

	
	}
}
}