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

	//Active ou désactive la zone de dessin
	public void setIsSelect(bool b){
		isSelected = b;
	}

	//Pour Aurelien : rend la texture dessinee
	public Texture2D getTex(){
		return tex;
	}
	void Update ()
	//void OnGUI ()
	{
		//Event evt = Event.current;
		largeurTrait = ((int)dm.getDiam());

		if (/*evt.isMouse && */Input.GetMouseButton (0) && !isSelected) 
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

				dessinContinu(lastPosX,lastPosY,(int)(uv.x * tex.width),(int)(uv.y * tex.height));

				tex.Apply ();
				gameObject.renderer.material.SetTexture(0, tex);
				if(Input.GetMouseButton (0)){
					lastPosX = (int)(uv.x * tex.width);
					lastPosY = (int)(uv.y * tex.height);
				}

			}
		}
		if(!Input.GetMouseButton (0)){
			lastPosX = -1;
			lastPosY = -1;
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

	//Cree une ligne continu entre chaque point
	public void dessinContinu(int x1, int y1, int x2, int y2){
		int i;
		i = norme(x1, y1, x2, y2);
		dessinContinuRec(x1, y1, x2, y2, i);

	}//dessinContinu

	public void dessinContinuRec(int x1, int y1, int x2, int y2, int longueur){
		int i;
		if (longueur <= 1) return;
		if(x1==x2){
			for (i= Mathf.Min(x1,x2); i<=Mathf.Max (x1,x2);i++)
				dessinePoint(i,y1);
			return;
			}
		if(y1==y2){
			for (i= Mathf.Min(y1,y2); i<=Mathf.Max (y1,y2);i++)
				dessinePoint(x1,i);
			return;
			}

		//Nord-Est
		if(x1<=x2 && y1<=y2){
			x1++;
			y1++;
			dessinePoint(x1,y1);
			dessinContinuRec(x1,y1,x2,y2,norme(x1,y1,x2,y2));
		}
		//Sud-Est
		if(x1<=x2 && y1>y2){
			x1++;
			y1--;
			dessinePoint(x1,y1);
			dessinContinuRec(x1,y1,x2,y2,norme(x1,y1,x2,y2));
		}
		//Sud-Ouest
		if(x1>x2 && y1>y2){
			x1--;
			y1--;
			dessinePoint(x1,y1);
			dessinContinuRec(x1,y1,x2,y2,norme(x1,y1,x2,y2));
		}
		//Nord-Ouest
		if(x1>x2 && y1<=y2){
			x1--;
			y1++;
			dessinePoint(x1,y1);
			dessinContinuRec(x1,y1,x2,y2,norme(x1,y1,x2,y2));
		}
	}

	//rend la distance entre deux points
	private int norme(int x1, int y1, int x2, int y2){
		return (int) Mathf.Sqrt (Mathf.Pow ((x2 - x1), 2) + Mathf.Pow ((y2 - y1), 2));
	}

}
