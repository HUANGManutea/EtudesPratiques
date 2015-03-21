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
	
	// Use this for initialization
	void Start () {
		largeurEcran = Screen.width;
		hauteurEcran = Screen.height;
		
		largeur = largeurEcran * (W - X);
		hauteur = hauteurEcran * (H - Y);
		
		Vector3 newScale = new Vector3(largeur, 1, hauteur); // Les dimensions souhaités
		transform.localScale = newScale;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
