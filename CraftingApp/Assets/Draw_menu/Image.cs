using UnityEngine;
using System.Collections;

public class Image : MonoBehaviour {
	public UnityEngine.UI.Image go;
	public Draw_menu dm;
	// Use this for initialization
	void Start () {
		//GetComponent<UnityEngine.UI.Image>().color = Color.blue;	
		go.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		go.color = dm.getColor ();
	}
}
