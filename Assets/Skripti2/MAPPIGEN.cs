using UnityEngine;
using System.Collections;
using System;
public class MAPPIGEN : MonoBehaviour {


	public int height;
	public int width;

	public string seed;
	public bool useRandomSeed;

	[Range(0,100)]
	public int randomFillPercent;



	int[,] map;



	void Start(){
	
		GenerateMap ();
		RandomFillMap ();
	
	
	}

	void GenerateMap(){
	
		map = new int[width,height];

		for (int i =0; i<5; i++) {
		
			smoothMap();
		
		
		}

	
	}

	void RandomFillMap(){

		if (useRandomSeed) {
		
		
			seed = Time.time.ToString();
		
		
		
		}
	
		System.Random pseudoRandom = new System.Random (seed.GetHashCode ());

		for (int x =0; x <width; x++) {
			for (int y =0; y <height; y++) {

				if(x==0||x==width-1||y==0||y==height-1){
					map[x,y] =1;
				
				}
				else{
				map[x,y] = (pseudoRandom.Next(0,100) <randomFillPercent)? 1: 0;
				
				}
				
			}
		
		
		
		}
	
	
	
	
	}




	void smoothMap(){
	
		for (int x =0; x <width; x++) {


			for (int y =0; y <height; y++) {

				int neighbourWallTiles = GetSurroundingWallCount(x,y);
			
					if(neighbourWallTiles>4)
					map[x,y]=1;
				else if(neighbourWallTiles<4)
					map[x,y]=0;
			
				
				
			
			}
		}
	}


	int GetSurroundingWallCount (int gridx, int gridy){
		int wallCount = 0;
		for (int neighbourx = gridx-1; neighbourx <= gridx+1; neighbourx++) {
		
			for (int neighboury = gridy-1; neighboury <= gridy+1; neighboury++) {
				if(neighbourx>=0 && neighbourx < width && neighboury>=0 && neighboury<height){
				if(neighbourx!=gridx || neighboury!=gridy){

					wallCount+=map[neighbourx,neighboury];
				
				
					}
				}

				else{
				
					wallCount++;
				
				
				}
				                                                                              
				                                                                            
		
		}
		
	}

		return wallCount;
	
	
	}




	void OnDrawGizmos(){
	
	
	if (map != null) {
			for (int x =0; x <width; x++) {
				for (int y =0; y <height; y++) {
					Gizmos.color = (map[x,y] ==1)? Color.black: Color.white;
					Vector3 pos = new Vector3(-width/2+x+0.5f, -height/2+y+0.5f,0);
					Gizmos.DrawCube(pos,Vector3.one);
					
					
					
				}
				
				
				
			}



		
		
		
		
		
		
		}
		           
	
	
	
	
	
	
	
	}



}
