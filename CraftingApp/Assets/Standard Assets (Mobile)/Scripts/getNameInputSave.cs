using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*this class is used to get the nameInput in the "Save" menu*/
public class getNameInputSave : MonoBehaviour {
	public GameObject textfield;
	public static string name = "";
	
	void Start(){
		name = textfield.GetComponent<InputField>().text; //getting the textfield content
	}
}
