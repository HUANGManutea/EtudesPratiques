using UnityEngine;
using System.Collections;
using UnityEditor;

/*this class is used to "transform" a gameobject from the scene to a .prefab file in the "Resources" folder*/
public class gameObjToPrefab : MonoBehaviour {
	//setting up the path to the "Resources" folder
	public static string prefabPath = "Assets/Standard Assets (Mobile)/Resources/";
	//the gameobject to "transform"
	public GameObject go;

	void Start () {
		prefabPath+=""+getNameInputSave.name+".prefab"; //creating the path to the .prefab 
		Object prefab = PrefabUtility.CreateEmptyPrefab(prefabPath); //creating the empty .prefab
		PrefabUtility.ReplacePrefab(go,prefab,ReplacePrefabOptions.ConnectToPrefab); //updating the empty .prefab with the actual gameobject data
	}

}
