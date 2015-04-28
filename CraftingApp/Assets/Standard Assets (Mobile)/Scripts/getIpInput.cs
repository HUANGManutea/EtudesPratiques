using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getIpInput : MonoBehaviour {
	public GameObject textfield;
	public static string ip = "";

	void Start(){
		ip = textfield.GetComponent<InputField>().text;
		Debug.Log(ip);
	}
}
