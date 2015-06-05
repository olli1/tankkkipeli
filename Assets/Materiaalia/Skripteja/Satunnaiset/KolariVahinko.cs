using UnityEngine;
using System.Collections;

public class KolariVahinko : MonoBehaviour {
	public float piste = 10;

	public int health = 1;//healthi muuneltavissa

	public float invulnPeriod = 0;

	Transform HealthTynnyri;

	float invulnTimer = 0;
	int correctLayer;



	SpriteRenderer[] spriteRend;


	public void addHP(int h){
		health += h;
	}

	void Start(){
	

		correctLayer = gameObject.layer;//tallettaa alussa pelaaja layerin
	
//		spriteRend = GetComponent<SpriteRenderer> ();

		if (spriteRend == null) {
		
			spriteRend = transform.GetComponentsInChildren<SpriteRenderer> ();


		}
	}












	void OnTriggerEnter2D(Collider2D other){

	
		if (other.tag != "Health") {

			health--;//törmäyksessä vähentää health pisteen
			invulnTimer = invulnPeriod; //aika kuinka kauan layer vaihdettuna 

	

			gameObject.layer = 10; //vaihta layeria
		}
	

	


}






	void Update(){





		if (invulnTimer >= 0) {
			invulnTimer -= Time.deltaTime;//vähentää 
		}
		
		
		



			if (invulnTimer >= 0) {
		
			gameObject.layer = correctLayer; //vaihtaa layerin takaisin kun aika on täysi
				
			foreach (SpriteRenderer i in spriteRend) {
				if (!i.enabled) {
					i.enabled = true;
				} else {

					i.enabled = false;
				
				}
	
			}

		} else {

			foreach (SpriteRenderer i in spriteRend)
				i.enabled = true;

			gameObject.layer = correctLayer;
		}







			if (health <= 0) { //aktivoi tuhoutumisen
				Die ();
				if(transform.tag == "Enemy"){
				GameObject.Find ("Controlleri").GetComponent<Kontrolloi>().lisaa(piste);

				/*if(GameObject.Find ("Controlleri").GetComponent<Kontrolloi>().pisteet>=90){

					Lataa uusi kenttä

                    }*/
			
			}
			
			}

	
		}



	void Die()//tuhoutuminen
	{
		Destroy (gameObject);
		
	}





}
