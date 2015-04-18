using UnityEngine;

public class CameraDrag : MonoBehaviour
{	
	//vitesse de rotation
	public float dragSpeed = 8;

	//objet autour duquel on veut tourner
	public GameObject go;

	//coordonnées du coin supérieur gauche
	public float X; 
	public float Y;
	//coordonnées du coin inférieur droit
	public float W;
	public float H;

	//taille de l'écran
	private int largeur;
	private int hauteur;

	void Start(){
			largeur = Screen.width;
			hauteur = Screen.height;	
		}

	void Update()
	{
		//si on appuie
		if (Input.GetMouseButton(0)){
			Vector3 pos = Input.mousePosition;

		 //si la souris est dans l'écran
		 if( (pos.x > X*largeur && pos.x < W*largeur) && (pos.y > Y*hauteur && pos.y < H*hauteur)) {

				//on récupère le déplacement
				float origine = Input.GetAxis("Mouse X");
				float origine2 = Input.GetAxis("Mouse Y"); 

				//on tourne autour pour le déplacement selon X
				transform.RotateAround (go.transform.position, Vector3.up, origine*dragSpeed);
				//on zoom/dezoom pour le déplacement selon Y
				transform.Translate (Vector3.forward * origine2 * 5, transform);
			}
		}

	}

	
	
}