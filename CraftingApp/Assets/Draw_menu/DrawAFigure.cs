using UnityEngine;
using System.Collections;

public class DrawAFigure : MonoBehaviour {

	public bool isSelected;
	public Draw_menu dm;
	private Texture2D tex;
	public int largeurTrait;

	void Start () {
		isSelected = false;
		Texture2D tex = new Texture2D(600,300);
		gameObject.renderer.material.SetTexture(0, tex);

	}

	public void setIsSelect(bool b){
		isSelected = b;
	}
	
	void OnGUI ()
	{
		Event evt = Event.current;
		largeurTrait = ((int)dm.getDiam());

		if (evt.isMouse && Input.GetMouseButton (0) && !isSelected) 
		{

			// Utiliser un Ray qui coupe la plan en au niveau de la mousePosition
			
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			
			if (collider.Raycast (ray, out hit, Mathf.Infinity))
			{
				// Trouver les coordonnées u,v de la texture

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
					if(norme(x,y,i,j)<=largeurTrait)
				   		tex.SetPixel (i, j, dm.getColor ());
				}
			}
	}

	//Dessine une ligne entre deux points
	//MARCHE PAS
	void dessineLigne (int x1, int y1, int x2, int y2){
		int points = nbPoints (x1, y1, x2, y2);

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

	//Nombre points maximums à mettre entre deux points pour dessiner une ligne
	private int nbPoints (int x1, int y1, int x2, int y2){
		return Mathf.Min ((Mathf.Max (x1,x2) - Mathf.Min(x1,x2)),(Mathf.Max (y1,y2) - Mathf.Min(y1,y2)));
	}

	//rend la distance entre deux points
	private int norme(int x1, int y1, int x2, int y2){
		return (int) Mathf.Sqrt (Mathf.Pow ((x2 - x1), 2) + Mathf.Pow ((y2 - y1), 2));
	}

}
