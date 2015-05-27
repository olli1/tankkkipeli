using UnityEngine;
using System.Collections;

public class PelaajaAmpuu : MonoBehaviour {

	public GameObject bulletPrefab;

	public Vector3 bulletOffset = new Vector3 (0, 0, 0);//voi hienosäätää ammuksen lähtökohtaa
	
    public float viive = 0.25f;
	float jaahyAjastin = 0;



	// Use this for initialization
	void Start () {
	

		ampuu = transform.Find ("Ampupiste");//löytää pelaajan gameobjektissa olevan empty child objektin joka määrittää ammuksen lähtöpaikan



	}

	Transform ampuu;//tämä että Instantiate onnistuu
	
	// Update is called once per frame
	void Update () {
	
		jaahyAjastin -= Time.deltaTime;

		if (Input.GetMouseButton (0) && jaahyAjastin <= 0) 
		{
			Debug.Log("pam");	
			jaahyAjastin = viive;
		
			Instantiate(bulletPrefab,ampuu.position+bulletOffset, ampuu.rotation);//ammuksen lähtöpaikan määritys ja ammuksen luonti kun ammutaan

		}


	}
}
