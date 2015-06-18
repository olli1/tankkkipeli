using UnityEngine;
using System.Collections;

public class Tulitus : MonoBehaviour {



	public float viive = 0.25f;
	float jaahyAjastin = 0;


	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {



		jaahyAjastin -= Time.deltaTime;
		
		if (Input.GetMouseButton (0) && jaahyAjastin <= 0) {
		

		
		}


	
	}
}
