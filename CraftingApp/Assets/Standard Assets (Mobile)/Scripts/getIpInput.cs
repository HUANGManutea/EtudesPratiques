using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this class is used in the "Options" menu, to get the IpInput in the textfield
public class getIpInput : MonoBehaviour {
	public GameObject textfield;
	public static string ip = "";

	void Start(){
		ip = textfield.GetComponent<InputField>().text; //getting the textfield content
	}
}
