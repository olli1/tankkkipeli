using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
[CustomEditor(typeof(Grid))]
public class GridEditor : Editor {

	//4. How To Create a 2D Map Editor in Unity - Create a Selection Popup [C#] 6:55



	Grid grid;

	private int oldIndex;

	void OnEnable(){

		oldIndex = 0;
	
		grid = (Grid)target;
	}



	[MenuItem("Assets/Create/TileSet")]

	static void CreateTileSet(){
	                            
		var asset = ScriptableObject.CreateInstance<TileSet> ();
		var path = AssetDatabase.GetAssetPath (Selection.activeObject);



		if (string.IsNullOrEmpty (path)) {
		
			path = "Assets";
		
		}else if(Path.GetExtension(path)!=""){
		
			path = path.Replace(Path.GetFileName(path),"");
		}else{ 

			path+="/";
		
		}


		var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "TileSet.asset");
		AssetDatabase.CreateAsset(asset, assetPathAndName);
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
		asset.hideFlags = HideFlags.DontSave;



	
	}


	public override void OnInspectorGUI(){
		//base.OnInspectorGUI ();
	
		grid.width = createSlider ("Width", grid.width);
		grid.height = createSlider ("Heigth", grid.height);

		if (GUILayout.Button ("Open Grid Window")) {
		
			GridWindow window = (GridWindow)EditorWindow.GetWindow(typeof(GridWindow));
			window.init();
		
		}

		//Tile Prefab
		EditorGUI.BeginChangeCheck ();
		var newTilePrefab = (Transform)EditorGUILayout.ObjectField ("Tile Prefab", grid.tilePrefab, typeof(Transform), false);

		if(EditorGUI.EndChangeCheck()){
			grid.tilePrefab = newTilePrefab;
			Undo.RecordObject(target,"Grid changed");

}


		//TileMap

		EditorGUI.BeginChangeCheck ();

		var newTileSet = (TileSet)EditorGUILayout.ObjectField ("Tileset", grid.tileset, typeof(TileSet), false);

		if (EditorGUI.EndChangeCheck ()) {
		
			grid.tileset = newTileSet;
			Undo.RecordObject(target, "Grid changed");
		
		}


		if (grid.tileset != null) {
			EditorGUI.BeginChangeCheck();

			var names = new string[grid.tileset.prefabs.Length];
			var values = new int[names.Length];


			for(int i =0; i<names.Length; i++){
			
			
				names[i] = grid.tileset.prefabs[i]!=null ? grid.tileset.prefabs[i].name:"";

				values[i] =i;
			}

			var index = EditorGUILayout.IntPopup("Select Tile", oldIndex,names,values); 

		if(EditorGUI.EndChangeCheck()){
				Undo.RecordObject(target, "Grid changed");
				if(oldIndex != index){
					oldIndex = index;
					grid.tilePrefab = grid.tileset.prefabs[index];


					float width = grid.tilePrefab.GetComponent<Renderer>().bounds.size.x;
					float height = grid.tilePrefab.GetComponent<Renderer>().bounds.size.y;

					grid.width = width;
					grid.height = height;

				
				}
			 }
		}
	}

	private float createSlider(string labelName, float sliderPosition){
	
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Grid" + labelName);
		sliderPosition = EditorGUILayout.Slider (sliderPosition,1f,100f,null);
		GUILayout.EndHorizontal ();
	
	
		return sliderPosition;
	}
	                          



	void OnSceneGUI(){
	
		int controllid = GUIUtility.GetControlID (FocusType.Passive);

		Event e = Event.current;
		Ray ray = Camera.current.ScreenPointToRay (new Vector3 (e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
		Vector3 mousePos = ray.origin;

		if (e.isMouse && e.type == EventType.MouseDown && e.button == 0) {
		
			GUIUtility.hotControl = controllid;
			e.Use ();

			GameObject gameObject;
			Transform prefab = grid.tilePrefab;


			if (prefab) {
			
				Undo.IncrementCurrentGroup ();

				gameObject = (GameObject)PrefabUtility.InstantiatePrefab (prefab.gameObject);

				Vector3 alligned = new Vector3 (Mathf.Floor (mousePos.x / grid.width) * grid.width + grid.width / 2.0f, 
				                               Mathf.Floor (mousePos.y / grid.height) * grid.height + grid.height / 2.0f, 0.0f);
				gameObject.transform.position = alligned;
				gameObject.transform.parent = grid.transform;

			
				Undo.RegisterCreatedObjectUndo (gameObject, "Create" + gameObject.name);

			
			}

		
		}
	

		if (e.isMouse && e.type == EventType.MouseDown && e.button == 1) {
		
			GUIUtility.hotControl = controllid;

			Vector3 alligned = new Vector3 (Mathf.Floor (mousePos.x / grid.width) * grid.width + grid.width / 2.0f, 
			                               Mathf.Floor (mousePos.y / grid.height) * grid.height + grid.height / 2.0f, 0.0f);
			
			Transform transform = GetTransformFromPosition (alligned);

			if (transform != null) {
			
			DestroyImmediate (transform.gameObject);
			
		
			
		}

		if (e.isMouse && e.type == EventType.mouseUp) {
		
			GUIUtility.hotControl = 0;
			e.Use ();
		}

	}

	
	}

	Transform GetTransformFromPosition(Vector3 alligned){
	
		int i = 0;
		    while (i < grid.transform.childCount){
				Transform transform = grid.transform.GetChild(i);
				if(transform.position == alligned){
				return transform;
			
			}
		
			i++;
		}


	return null;

}

}

	
	







