using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getNameInput : MonoBehaviour {
	public GameObject textfield;
	public static string name = "";
	
	void Start(){
		name = textfield.GetComponent<InputField>().text;
		Debug.Log(name);
	}
}
