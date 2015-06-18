using UnityEngine;
using System.Collections;

public class ammus : MonoBehaviour {

	public float health = 1;//healthi muuneltavissa
	

	int correctLayer;
	

	
	
	void Start()
	{
		
		correctLayer = gameObject.layer;//tallettaa alussa pelaaja layerin
		
	}
		

	
	
	
	
	void OnTriggerEnter2D()
		
	{
		Debug.Log ("triggeri");//testi
		
		
		
		health--;//törmäyksessä vähentää health pisteen
		 
		
		
		
		
		
	}
	
	
	void Update(){
		
		
		

			
			
			
			
			if (health <= 0) { //aktivoi tuhoutumisen
				Die ();
				
			
			
			
		}
		
	}
	
	void Die()//tuhoutuminen
	{
		Destroy (gameObject);
		
	}










}
