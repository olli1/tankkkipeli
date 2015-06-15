using UnityEngine;
using System.Collections;

public class Skripti : MonoBehaviour {


	//float timer =0;

	float speed = 0.04f;

	// Use this for initialization
	void Start () {

		//ampu = transform.Find ("Ampupiste");

	}



	//bool shootside = false;
	
	//Transform ampu;





	/*void shoot(){
		if (timer < Time.time) {
			if(shootside){
				GameObject tmp = Instantiate(Resources.Load ("beam"),ampu.position,ampu.rotation) as GameObject;
				bullet tmp2 = tmp.GetComponent<bullet>();
				tmp2.speed = 80;
				tmp2.taga = transform.tag;
				shootside = false;
				timer +=0.25f;
				}

			/*else {
				GameObject tmp = Instantiate(Resources.Load ("beam"),rightg.position,rightg.rotation) as GameObject;
				shootside = true;
				bullet tmp2 = tmp.GetComponent<bullet>();
				tmp2.speed = 80;
				tmp2.taga = transform.tag;
				timer +=0.25f;
				
			}
		
		}
		
		
	}*/









	
	// Update is called once per frame
void Update () {

		/*if (Input.GetMouseButton (0)) {
			Debug.Log("toimii");
			shoot ();
		}*/


		
		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 lookat = transform.position - mouse;
		float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg +90;
		//transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		 transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.AngleAxis (angle, Vector3.forward),speed);
	
	}


    void FixedUpdate(){



	
	
	
	}


}
