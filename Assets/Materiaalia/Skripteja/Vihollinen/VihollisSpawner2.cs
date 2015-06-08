using UnityEngine;
using System.Collections;

public class VihollisSpawner2 : MonoBehaviour {
	public int kertoja;
	public GameObject ExitSign;
	public GameObject enemyPrefab;
	public GameObject[] enemys;
	float spawnDistance = 10f;

	float enemyRate = 5; 

	float nextEnemy =1;

	float sammu;
	

		// Use this for initialization
	void Start () {
		enemys = Resources.LoadAll<GameObject> ("enemys");



	}
	
	// Update is called once per frame
	void Update () {
		if (kertoja > 0) {

			nextEnemy -= Time.deltaTime;

			if (nextEnemy <= 0) {

				nextEnemy = enemyRate;
				enemyRate *= 0.9f;
				if (enemyRate < 2)
					kertoja--;






				Vector3 offset = Random.insideUnitCircle*6;
				
				offset.z = 0;
				
				offset = offset.normalized * spawnDistance;
				int tmp = Random.Range (0, enemys.Length);
				Instantiate (enemys [tmp], transform.position + offset, transform.rotation);
				Debug.Log (tmp);






		
			}
	
	

		}
		if(kertoja<=0 && !(GameObject.FindGameObjectWithTag("Enemy"))){
			
			ExitSign.SetActive(true);
		}

	}
	


	
	
	






}
