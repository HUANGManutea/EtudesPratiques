using UnityEngine;
using System.Collections;
using UnityEditor;

public class gameObjToPrefab : MonoBehaviour {
	public static string prefabPath = "Assets/Standard Assets (Mobile)/Prefabs/";
	public GameObject go;
	// Use this for initialization
	void Start () {
		prefabPath+=""+getNameInput.name+".prefab";
		Debug.Log(prefabPath);
		Object prefab = PrefabUtility.CreateEmptyPrefab(prefabPath);
		Debug.Log("Prefab vide créé");
		PrefabUtility.ReplacePrefab(go,prefab,ReplacePrefabOptions.ConnectToPrefab);
		Debug.Log("L'objet a été correctement ajouté au prefab");
	}

}
