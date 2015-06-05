using UnityEngine;
using System.Collections;

public class HealttiBarreli : MonoBehaviour {
	public float speedi;

	public float barrellHealth = 1;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		 
		transform.Rotate(new Vector3(0,0, speedi * Time.deltaTime));






	

		if(barrellHealth <= 0){ //aktivoi tuhoutumisen
			
			Die ();
		}



	
	}




	public int addhp = 1;



	void OnTriggerEnter2D(Collider2D other)
		
	{
		Debug.Log ("triggeri");//testi
		


		barrellHealth--;//törmäyksessä vähentää health pisteen

		if (other.tag == "Player") {

			other.SendMessageUpwards("addHP", addhp,SendMessageOptions.DontRequireReceiver);
	}
		
		
		
		
	}






	void Die()//tuhoutuminen
	{
		Destroy (gameObject);
		
	}







}
