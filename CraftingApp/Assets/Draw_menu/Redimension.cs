using UnityEngine;
using System.Collections;

public class Redimension : MonoBehaviour {
	//coordonnées du coin supérieur gauche
	public float X; 
	public float Y;
	//coordonnées du coin inférieur droit
	public float W;
	public float H;

	//taille de l'écran
	private int largeurEcran;
	private int hauteurEcran;

	//taille voulu
	private float largeur;
	private float hauteur;

	void Start () {
		//on place l'objet ou on veut dans la scene
		transform.localPosition = new Vector3 (11, -17, -10);

		largeurEcran = Screen.width;
		hauteurEcran = Screen.height;
		largeur =  largeurEcran * (W-X);
		hauteur = hauteurEcran * (H-Y);

		//ratio de 10 du à la size de Main camera
		transform.localScale = new Vector3(largeur/10, 1, hauteur/10);


	}

	//getters
	public float getLargeur(){
		return largeur;
	}
	public float getHauteur(){
		return hauteur;
	}


}
