using UnityEngine;
using System.Collections;
using System;


public class DrawAFigure : MonoBehaviour {

	public int isSelected;
	public Draw_menu dm;
	private Texture2D tex;
	public Redimension dimension;
	private Color color;
	public int largeurTrait;
	protected static int texWidth;
	protected static int texHight;
	protected int lastPosX;
	protected int lastPosY;

	void Start () {
		isSelected = 0;
		texWidth=(int)dimension.getLargeur();
		texHight=(int)dimension.getHauteur();
		Texture2D tex = new Texture2D(texWidth,texHight,TextureFormat.RGBA32,false);
		for(int i=0;i<=texWidth;i++){
			for(int j=0;j<=texHight;j++)
				tex.SetPixel(i,j,Color.clear);
		}
		tex.Apply();
		gameObject.renderer.material.SetTexture(0, tex);
		lastPosX = -1;
		lastPosY = -1;
	}

	//reinitialise la zone
	public void reboot(){
		for(int i=0;i<=texWidth;i++){
			for(int j=0;j<=texHight;j++)
				tex.SetPixel(i,j,Color.clear);
		}
		tex.Apply();
	}


	//Active ou désactive la zone de dessin
	public void setIsSelect(int i){
		System.Threading.Thread.Sleep(50);
		isSelected += i;
		print (isSelected);
	}

	public void initIsSelect(){
		System.Threading.Thread.Sleep(150);
		isSelected =0;
		print (isSelected);
	}

	//Pour Aurelien : rend la texture dessinee
	public Texture2D getTex(){
		tex.Apply ();
		return tex;
	}
	void Update ()
	//void OnGUI ()
	{
		//Event evt = Event.current;
		largeurTrait = ((int)dm.getDiam());
		color = dm.getColor ();


		if (/*evt.isMouse && */Input.GetMouseButton (0) && (isSelected==0)) 
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
				if(dm.getTool()==Draw_menu.Tools.PENCIL){
					dessinePoint ((int)(uv.x * tex.width), (int)(uv.y * tex.height), color);
					dessinContinu(lastPosX,lastPosY,(int)(uv.x * tex.width),(int)(uv.y * tex.height), color);
				}
				if(dm.getTool()==Draw_menu.Tools.ERASER){
					dessinePoint ((int)(uv.x * tex.width), (int)(uv.y * tex.height), Color.clear);
					dessinContinu(lastPosX,lastPosY,(int)(uv.x * tex.width),(int)(uv.y * tex.height), Color.clear);
				}
				if(dm.getTool()==Draw_menu.Tools.BUCKET){
					int x = (int)(uv.x * tex.width);
					int y = (int)(uv.y * tex.height);
					bucket (x,y,color,tex.GetPixel (x,y),tex);
				}


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
	void dessinePoint (int x, int y, Color c){
		// y<largeurTrait || y>(300-largeurTrait)
		
		//Pointeur proche du bord gauche
		if(x<largeurTrait)
		{
			for (int i=0; i<=(x+largeurTrait); i++) {
				for (int j=y-largeurTrait; j<=(y+largeurTrait); j++) {
					if(norme(x,y,i,j)<=largeurTrait)
						tex.SetPixel (i, j, c);
				}
			}
			return;
		}

		//Pointeur proche du bord droit
		if(x>(texWidth-(largeurTrait+1)) && (x<(texWidth+largeurTrait+1)))
		{
			for (int i=x; i<=texWidth-1; i++) {
				for (int j=y-largeurTrait; j<=(y+largeurTrait); j++) {
					if(norme(x,y,i,j)<=largeurTrait)
						tex.SetPixel (i, j, c);
				}
			}
			return;
		}
		
		//Pointeur proche du bord bas
		if(y<largeurTrait)
		{
			for (int i=x; i<=(x+largeurTrait); i++) {
				for (int j=1; j<=(y+largeurTrait); j++) {
					if(norme(x,y,i,j)<=largeurTrait)
						tex.SetPixel (i, j, c);
				}
			}
			return;
		}
		
		//Pointeur proche du bord haut
		if(y>(texHight-(largeurTrait+1)) && (y<(texHight+largeurTrait)))
		{
			for (int i=x; i<=(x+largeurTrait); i++) {
				for (int j=y-largeurTrait; j<=texHight-1; j++) {
					if(norme(x,y,i,j)<=largeurTrait)
						tex.SetPixel (i, j, c);
				}
			}
			return;
		}

		//Sinon on dessine un point
		for (int i=x-largeurTrait; i<=(x+largeurTrait); i++) {
			for (int j=y-largeurTrait; j<=(y+largeurTrait); j++) {
				if(norme(x,y,i,j)<=largeurTrait)
			   		tex.SetPixel (i, j, c);
			}
		}

	}

	//Cree une ligne continu entre chaque point
	public void dessinContinu(int x1, int y1, int x2, int y2, Color c){
		int i;
		i = norme(x1, y1, x2, y2);
		dessinContinuRec(x1, y1, x2, y2, i, c);

	}//dessinContinu

	public void dessinContinuRec(int x1, int y1, int x2, int y2, int longueur, Color c){
		int i;
		if (longueur <= 1) return;
		if(x1==x2){
			for (i= Mathf.Min(x1,x2); i<=Mathf.Max (x1,x2);i++)
				dessinePoint(i, y1, c);
			return;
			}
		if(y1==y2){
			for (i= Mathf.Min(y1,y2); i<=Mathf.Max (y1,y2);i++)
				dessinePoint(x1, i, c);
			return;
			}

		//Nord-Est
		if(x1<=x2 && y1<=y2){
			x1++;
			y1++;
			dessinePoint(x1,y1, c);
			dessinContinuRec(x1,y1,x2,y2,norme(x1,y1,x2,y2), c);
		}
		//Sud-Est
		if(x1<=x2 && y1>y2){
			x1++;
			y1--;
			dessinePoint(x1,y1, c);
			dessinContinuRec(x1,y1,x2,y2,norme(x1,y1,x2,y2), c);
		}
		//Sud-Ouest
		if(x1>x2 && y1>y2){
			x1--;
			y1--;
			dessinePoint(x1,y1, c);
			dessinContinuRec(x1,y1,x2,y2,norme(x1,y1,x2,y2), c);
		}
		//Nord-Ouest
		if(x1>x2 && y1<=y2){
			x1--;
			y1++;
			dessinePoint(x1,y1, c);
			dessinContinuRec(x1,y1,x2,y2,norme(x1,y1,x2,y2), c);
		}
	}


	private Color colorToBucket;
	private Stack lesX = new Stack(texWidth*texHight);
	private Stack lesY = new Stack(texWidth*texHight);

	//Pot de peinture
	//http://fr.wikipedia.org/wiki/Algorithme_de_remplissage_par_diffusion
	private void bucket(int x, int y, Color cApply,Color cOrigin,Texture2D tex){
		//Debug.Log("bucket " + cApply + " " + cOrigin );
		if(x>=0 && x<texWidth && y>=0 && y<texHight){
			if(!equals(tex.GetPixel(x,y),cApply)  &&  equals (tex.GetPixel(x,y), cOrigin)){
				lesX.Push(x);
				lesY.Push(y);
				//tex.SetPixel(x,y,cApply);
				//tex.Apply();
				bucketRec (x,y+1,cApply,cOrigin);
				/*bucket (x,y-1,cApply,cOrigin,tex);
				bucket (x+1,y,cApply,cOrigin,tex);
				bucket (x-1,y,cApply,cOrigin,tex);*/
			}
		}
		while (lesX.Count != 0){
			tex.SetPixel((int)lesX.Pop(),(int)lesY.Pop(),cApply);
		}
	}

	//rend la distance entre deux points
	private int norme(int x1, int y1, int x2, int y2){
		return (int) Mathf.Sqrt (Mathf.Pow ((x2 - x1), 2) + Mathf.Pow ((y2 - y1), 2));
	}

	//Compare deux Color
	private bool equals(Color c1,Color c2){
		return (c1.a == c2.a && c1.b == c2.b && c1.g == c2.g && c1.r == c2.r);
	}

	private void bucketRec(int x, int y,Color cApply, Color cOrigin){
		if(x>=0 && x<texWidth && y>=0 && y<texHight){
			if(!equals(tex.GetPixel(x,y),cApply)  &&  equals (tex.GetPixel(x,y), cOrigin)){
				lesX.Push(x);
				lesY.Push(y);

				bucketRec (x,y+1,cApply,cOrigin);
				bucketRec (x,y-1,cApply,cOrigin);
				bucketRec (x+1,y,cApply,cOrigin);
				bucketRec (x-1,y,cApply,cOrigin);
			}
		}
	}

}
