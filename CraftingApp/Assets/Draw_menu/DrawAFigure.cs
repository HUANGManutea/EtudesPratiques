using UnityEngine;
using System.Collections;

public class DrawAFigure : MonoBehaviour {

	public bool isSelected;
	public Draw_menu dm;
	private Texture2D tex;
	public int largeurTrait;
	protected int lastPosX;
	protected int lastPosY;

	void Start () {
		isSelected = false;
		Texture2D tex = new Texture2D(600,300);
		gameObject.renderer.material.SetTexture(0, tex);
		lastPosX = -1;
		lastPosY = -1;
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

				// Peindre ce point de la couleur selectionnee

				tex = (Texture2D)hit.transform.gameObject.renderer.sharedMaterial.mainTexture;
				if((lastPosX == -1) && (lastPosY == -1)){
					lastPosX = (int)(uv.x * tex.width);
					lastPosY = (int)(uv.y * tex.height);
				}
				dessinePoint ((int)(uv.x * tex.width), (int)(uv.y * tex.height));
				tex.Apply ();
				gameObject.renderer.material.SetTexture(0, tex);
				lastPosX = (int)(uv.x * tex.width);
				lastPosY = (int)(uv.y * tex.height);
			}
		}

	}

	//Dessine un poit de largeur largeurTrait aux coordonnées x et y
	void dessinePoint (int x, int y){
		// y<largeurTrait || y>(300-largeurTrait)
		
		//Pointeur proche du bord gauche
		if(x<largeurTrait)
		{
			for (int i=0; i<=(x+largeurTrait); i++) {
				for (int j=y-largeurTrait; j<=(y+largeurTrait); j++) {
					if(norme(x,y,i,j)<=largeurTrait)
						tex.SetPixel (i, j, dm.getColor ());
				}
			}
			return;
		}

		//Pointeur proche du bord droit
		if(x>(600-(largeurTrait+1)) && (x<(600+largeurTrait)))
		{
			for (int i=x; i<=599; i++) {
				for (int j=y-largeurTrait; j<=(y+largeurTrait); j++) {
					if(norme(x,y,i,j)<=largeurTrait)
						tex.SetPixel (i, j, dm.getColor ());
				}
			}
			return;
		}
		
		//Pointeur proche du bord bas
		if(y<largeurTrait)
		{
			for (int i=x; i<=(x+largeurTrait); i++) {
				for (int j=0; j<=(y+largeurTrait); j++) {
					if(norme(x,y,i,j)<=largeurTrait)
						tex.SetPixel (i, j, dm.getColor ());
				}
			}
			return;
		}
		
		//Pointeur proche du bord haut
		if(y>(300-(largeurTrait+1)) && (y<(300+largeurTrait)))
		{
			for (int i=x; i<=(x+largeurTrait); i++) {
				for (int j=y-largeurTrait; j<=299; j++) {
					if(norme(x,y,i,j)<=largeurTrait)
						tex.SetPixel (i, j, dm.getColor ());
				}
			}
			return;
		}

		//Sinon on dessine un point
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
		int points = norme (x1, y1, x2, y2);
		int tempX=x1,tempY=y1;

		while (points > largeurTrait){
			if(x1==x2){
				//Nord
				if(y1 <= y2){
					
				}
				//Sud
				if(y1 > y2){
					
				}
			}
			//Direction droite
			if(x1>x2){
				//Nord Est
				if(y1 <= y2){
					
				}
				//Est
				if(y1==y2){
					
				}
				//Sud Est
				if(y1 > y2){
					
				}

			}else{
				//Direction gauche
				//Sud Ouest
				if(y1 > y2){
					
				}
				//Ouest
				if(y1==y2){
					
				}
				//Nord Ouest
				if(y1 <= y2){
					
				}
			}

		}//while
	}

	//rend la distance entre deux points
	private int norme(int x1, int y1, int x2, int y2){
		return (int) Mathf.Sqrt (Mathf.Pow ((x2 - x1), 2) + Mathf.Pow ((y2 - y1), 2));
	}

}
