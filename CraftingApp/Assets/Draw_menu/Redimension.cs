using UnityEngine;
using System.Collections;

public class Redimension : MonoBehaviour {
	public float X; //Viewport Rec de la cam
	public float Y;
	public float W;
	public float H;
	private int largeurEcran;
	private int hauteurEcran;
	private float largeur;
	private float hauteur;
	public GameObject myobject;
	
	// Use this for initialization
	void Start () {
		myobject.transform.localPosition = new Vector3 (11, -17, -10);
		
		largeurEcran = Screen.width;
		hauteurEcran = Screen.height;
		//Debug.Log("aaaaaaaaaa " + largeurEcran + " " + hauteurEcran);
		
		largeur =  largeurEcran * (W-X);
		hauteur = hauteurEcran * (H-Y);
		//print (largeur);
		
		gameObject.transform.localScale = new Vector3(largeur/10, 1, hauteur/10);


	}

	public float getLargeur(){
		return largeur;
	}
	public float getHauteur(){
		return hauteur;
	}

	void Update () {
		


	}
}
