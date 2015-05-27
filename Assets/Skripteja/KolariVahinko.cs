using UnityEngine;
using System.Collections;

public class KolariVahinko : MonoBehaviour {


	public int health = 1;//healthi muuneltavissa

	public float invulnPeriod = 0;

	float invulnTimer = 0;
	int correctLayer;


	void Start()
	{

		correctLayer = gameObject.layer;//tallettaa alussa pelaaja layerin
	
	
	
	}







	void OnTriggerEnter2D()

	{
		Debug.Log ("triggeri");//testi



			health--;//törmäyksessä vähentää health pisteen
		    invulnTimer = invulnPeriod; //aika kuinka kauan layer vaihdettuna 

	

		gameObject.layer = 10; //vaihta layeria

	}


	void Update(){

		invulnTimer -= Time.deltaTime;//vähentää 
		if (invulnTimer <= 0) {
		
			gameObject.layer = correctLayer; //vaihtaa layerin takaisin kun aika on täysi
		
		}

	





		if (health <= 0) //aktivoi tuhoutumisen
		{
			Die();
			
		}

	
	}



	void Die()//tuhoutuminen
	{
		Destroy (gameObject);
		
	}



}
