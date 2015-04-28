using UnityEngine;
using System.Collections;
using UnityEditor;

public class load : MonoBehaviour {
	public GameObject parent;
	// Use this for initialization
	void Start () {
		GameObject go = Instantiate(Resources.Load(getNameInputLoad.name,typeof(GameObject)),parent.transform.position,Quaternion.identity) as GameObject;

	}
}
