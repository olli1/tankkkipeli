using UnityEngine;
using System.Collections;

public class HealttiBarreli : MonoBehaviour {

	float barrellHealth = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if(barrellHealth <= 0){ //aktivoi tuhoutumisen
			
			Die ();
		}



	
	}








	void OnTriggerEnter2D()
		
	{
		Debug.Log ("triggeri");//testi
		


		barrellHealth--;//törmäyksessä vähentää health pisteen

		
		
		
		
		
	}






	void Die()//tuhoutuminen
	{
		Destroy (gameObject);
		
	}







}
