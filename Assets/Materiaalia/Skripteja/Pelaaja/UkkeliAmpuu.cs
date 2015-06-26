using UnityEngine;
using System.Collections;

public class UkkeliAmpuu : MonoBehaviour {

	public GameObject bulletPrefab;



	GameObject liekki;

	public Vector3 bulletOffset = new Vector3 (0, 0, 0);//voi hienosäätää ammuksen lähtökohtaa
	
    public float viive = 0.30f;

	float jaahyAjastin = 0;


	int bulletLayer;



	// Use this for initialization
	void Start () {
	
		bulletLayer = gameObject.layer;


		ampuu = transform.Find ("Ampupiste");//löytää pelaajan gameobjektissa olevan empty child objektin joka määrittää ammuksen lähtöpaikan

		liekki = transform.Find ("Tuli").gameObject;//löydetään Tuli objekti



	}


	Transform ampuu;//tämä että Instantiate onnistuu

	float animeajastin = 0;
	// Update is called once per frame
	void Update () {
		if (liekki.activeSelf) {
			animeajastin += Time.deltaTime;
		}

		if(liekki.activeSelf && animeajastin >= 0.125f){
			liekki.SetActive(false);
			animeajastin = 0;
		}

		jaahyAjastin -= Time.deltaTime;

		if (Input.GetMouseButton (0) && jaahyAjastin <= 0) {

			if(!liekki.activeSelf){
			liekki.SetActive(true);
			}

			Debug.Log ("pam");	
			jaahyAjastin = viive;
		
				
			bulletPrefab.GetComponent<LiikeEteen>().maxSpeed = 11.5f;
		
				GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, ampuu.position + bulletOffset, ampuu.rotation);//ammuksen lähtöpaikan määritys ja ammuksen luonti kun ammutaan
			
			bulletGO.layer = bulletLayer;





			//Instantiate(bulletPrefab,ampuu.position+bulletOffset, ampuu.rotation);//ammuksen lähtöpaikan määritys ja ammuksen luonti kun ammutaan

		
		}
	








	}


}
