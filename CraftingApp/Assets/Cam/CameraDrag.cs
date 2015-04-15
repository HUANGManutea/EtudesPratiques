using UnityEngine;

public class CameraDrag : MonoBehaviour
{
	public float dragSpeed = 8;
	public GameObject go;//objet autour duquel on veut tourner
	public float X; //Viewport Rec de la cam
	public float Y;
	public float W;
	public float H;
	private int largeur;
	private int hauteur;

	void Start(){
			largeur = Screen.width;
			hauteur = Screen.height;
			
		}

	void Update()
	{
		Vector3 pos = Input.mousePosition;

		if (Input.GetMouseButton(0) && (pos.x > X*largeur && pos.x < W*largeur) && 
		    	(pos.y > Y*hauteur && pos.y < H*hauteur)) {
			float origine = Input.GetAxis("Mouse X");

			float origine2 = Input.GetAxis("Mouse Y"); 

			transform.RotateAround (go.transform.position, Vector3.up, origine*dragSpeed);
			transform.Translate (Vector3.forward * origine2 * 5, transform);
		}
		//Pos ();
		
	}

	void Pos(){
		Renderer[] child = go.GetComponentsInChildren<Renderer> ();
		float max = child[0].bounds.max.x;
		float min = child[0].bounds.min.x;
		foreach(Renderer o in child){
			max = Mathf.Max(max,o.bounds.max.x);
			min = Mathf.Min(min,o.bounds.min.x);
		}
		print (max +"  " + min);
	}
	
	
}