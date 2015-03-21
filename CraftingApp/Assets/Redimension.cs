using UnityEngine;
using System.Collections;

public class Redimension : MonoBehaviour {
	public float X; //Viewport Rec de la cam
	public float Y;
	public float W;
	public float H;
	private int largeurEcran;
	private int hauteurEcran;
	private int largeur;
	private int hauteur;
	public GameObject myobject;
	
	// Use this for initialization
	void Start () {
		largeurEcran = Screen.width;
		hauteurEcran = Screen.height;
		
		largeur = (int)( largeurEcran * (W - X));
		hauteur = (int)(hauteurEcran * (H - Y));
		
		//Vector3 newScale = new Vector3(largeur, 1, hauteur); // Les dimensions souhaités
		//transform.localScale = newScale;

		float currentSize = myobject.renderer.bounds.size.x+ (float)95;
		
		Vector3 scale = myobject.transform.localScale;

		print (currentSize);
		print (scale);

		scale.x = largeur * scale.x / currentSize;


		currentSize = myobject.renderer.bounds.size.y + (float)65; 
		print (currentSize);
		print (scale);
		
		scale.z = hauteur * scale.z / currentSize;
		
		myobject.transform.localScale = scale;

		//((Texture2D) (myobject.renderer.material.mainTexture)).Resize(largeur, hauteur);
		
	}
	
	// Update is called once per frame
	void Update () {
		/*largeurEcran = Screen.width;
		hauteurEcran = Screen.height;
		
		largeur = (int)( largeurEcran * (W - X));
		hauteur = (int)(hauteurEcran * (H - Y));
		
		//Vector3 newScale = new Vector3(largeur, 1, hauteur); // Les dimensions souhaités
		//transform.localScale = newScale;
		
		float currentSize = myobject.renderer.bounds.size.x+ (float)95;
		
		Vector3 scale = myobject.transform.localScale;
		
		print (currentSize);
		print (scale);
		
		scale.x = largeur * scale.x / currentSize;
		
		
		currentSize = myobject.renderer.bounds.size.y + (float)65; 
		print (currentSize);
		print (scale);
		
		scale.z = hauteur * scale.z / currentSize;
		
		myobject.transform.localScale = scale;
*/
	}
}
