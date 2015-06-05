using UnityEngine;
using System.Collections;

public class VihollinenAmpuu : MonoBehaviour {

	public GameObject bulletPrefab;

	GameObject liekki;//liitty piippuliekkiin
	
	public Vector3 bulletOffset = new Vector3 (0, 0, 0);//voi hienosäätää ammuksen lähtökohtaa
	
	public float viive = 0.50f;
	float jaahyAjastin = 0;

	int bulletLayer;

	Transform player;
	
	// Use this for initialization
	void Start () {

		bulletLayer = gameObject.layer;
		
		ampuu = transform.Find ("Ampupiste");//löytää pelaajan gameobjektissa olevan empty child objektin joka määrittää ammuksen lähtöpaikan

		liekki = transform.Find ("Tuli").gameObject;//liittyy piippuliekkiin
		
		
	}
	
	Transform ampuu;//tämä että Instantiate onnistuu

	float animeajastin = 0;
	// Update is called once per frame
	void Update () {

		if (player == null) {
			
			GameObject go =	GameObject.FindGameObjectWithTag("Player");
			
			
			
			
			if (go != null) {
				
				player = go.transform;
				
				
				
			}
			
		}

		if (liekki.activeSelf) {
			animeajastin += Time.deltaTime;//piippuliekkiin
		}
		
		if(liekki.activeSelf && animeajastin >= 0.125f){
			liekki.SetActive(false);
			animeajastin = 0;
		}








		
		jaahyAjastin -= Time.deltaTime;
		
		if (jaahyAjastin <= 0 && player !=null && Vector3.Distance(transform.position,player.position)<9) 
		{

			if(!liekki.activeSelf){
				liekki.SetActive(true);
			}






			Debug.Log("enemy pam");	
			jaahyAjastin = viive;
			
	  GameObject bulletGO =(GameObject)Instantiate(bulletPrefab,ampuu.position+bulletOffset, ampuu.rotation);//ammuksen lähtöpaikan määritys ja ammuksen luonti kun ammutaan

			//ammus tmp2 = bulletGO.GetComponent<ammus>();

			bulletGO.layer = bulletLayer; 	
		}
		
		
	}
}
