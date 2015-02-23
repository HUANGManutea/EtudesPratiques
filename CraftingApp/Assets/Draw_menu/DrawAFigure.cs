using UnityEngine;
using System.Collections;

public class DrawAFigure : MonoBehaviour {

	public bool isDrawing;
	public Draw_menu dm;
	private Texture2D tex;
	public int largeurTrait;

	void Start () {

		Texture2D tex = new Texture2D(600,300);
		gameObject.renderer.material.SetTexture(0, tex);

	}
	
	void OnGUI ()
	{
		Event evt = Event.current;
		largeurTrait = ((int)dm.getDiam());

		if (evt.isMouse && Input.GetMouseButton (0)) 
		{
			isDrawing = true;
			// Utiliser un Ray qui coupe la plan en au niveau de la mousePosition
			
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			
			if (collider.Raycast (ray, out hit, Mathf.Infinity) && isDrawing)
			{
				// Trouevr les coordonnées u,v de la texture

				Vector2 uv;
				uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
				uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;

				// Peindre ce point en noir (pour l'instant)

				tex = (Texture2D)hit.transform.gameObject.renderer.sharedMaterial.mainTexture;
				dessinePoint ((int)(uv.x * tex.width), (int)(uv.y * tex.height));
				tex.Apply ();
				gameObject.renderer.material.SetTexture(0, tex);

			}
		}

	}

	//Dessine un poit de largeur largeurTrait aux coordonnées x et y
	void dessinePoint (int x, int y){
			for (int i=x-largeurTrait; i<=(x+largeurTrait); i++) {
				for (int j=y-largeurTrait; j<=(y+largeurTrait); j++) {
					tex.SetPixel (i, j, dm.getColor ());
				}
			}
	}

	//Dessine une ligne entre deux points
	//MARCHE PAS
	void dessineLigne (int x1, int y1, int x2, int y2){
		if (x1 == x2) {
			for (int i = Mathf.Min(y1,y2); i<= Mathf.Max(y1,y2); i++)
				dessinePoint (x1, i);
		} else {
			int pente = (y2 - y1) / (x2 - x1);
			for (int i=Mathf.Min(x1,x2); i<=Mathf.Max(x1,x2); i++) {
				dessinePoint (i, i * pente);
			}
		}
	}

}
