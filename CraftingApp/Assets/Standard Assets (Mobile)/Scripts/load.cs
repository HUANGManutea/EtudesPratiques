using UnityEngine;
using System.Collections;
using UnityEditor;

//this class is used to load a previous work
public class load : MonoBehaviour {
	public GameObject parent;
	
	void Start () {
		// we get the gameobject corresponding to the NameInputLoad, stored in the "Resources" folder
		GameObject go = Instantiate(Resources.Load(getNameInputLoad.name,typeof(GameObject)),parent.transform.position,Quaternion.identity) as GameObject;
		go.transform.parent=parent.transform;
	}
}
