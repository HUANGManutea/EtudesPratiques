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


	}
	
	void Update () {
		
		myobject.transform.localPosition = new Vector3 (11, -17, -10);
		
		largeurEcran = Screen.width;
		hauteurEcran = Screen.height;
		Debug.Log("aaaaaaaaaa " + largeurEcran + " " + hauteurEcran);
		
		largeur =  largeurEcran * (W-X);
		hauteur = hauteurEcran * (H-Y);
		print (largeur);

		gameObject.transform.localScale = new Vector3(largeur/10, 1, hauteur/10);

		//le problème doit venir du résultat rendu ici, qui est inférieur à la valeur souhaiter
		/*double currentSize =  myobject.renderer.bounds.size.x;
		
		Vector3 scale = myobject.transform.localScale;
		
		print (currentSize);
		print (scale);
		
		scale.x = (float) (largeur * scale.x / currentSize);
		
		
		currentSize =  myobject.renderer.bounds.size.y ; 
		print (currentSize);
		print (scale);
		
		scale.z = (float)( hauteur * scale.z / currentSize);
		
		myobject.transform.localScale = scale;*/

	}
}
