using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Translate : MonoBehaviour {

	//transform de l'objet à déplacer
	Transform target;

	//enum des direction pour les switchs
	public enum Direction {X,Y,Z};

	//direction courante
	private Direction dir = Direction.X;

	//objet à déplacer
	private string name = "Exemple1";

	//camera qui suis l'objet lors du placement
	public Camera followObject;

	//sliders de taille (voir windows => placement menu)
	public Slider s;
	public Slider sX;
	public Slider sY;
	public Slider sZ;


	//fonction à supprimer au moment de la compilation(car exemple1 n'existera plus)
	void Start () {
		target = GameObject.Find(name).transform;
		dir = Direction.X;
	}

	//set de la figure à déplacer
	public void setName(string s){
		name = s;
		target = GameObject.Find(name).transform;
	}

	//translations
	public void up(){
		target.Translate (Vector3.up, followObject.transform);
	}

	public void down(){
		target.Translate (Vector3.down, followObject.transform);
	}
	public void right(){
		target.Translate (Vector3.right, followObject.transform);
	}
	public void left(){
		target.Translate (Vector3.left, followObject.transform);
	}


	//rotation, deux par axes, 5 choisi abitrairement pour la vitesse
	public void rLeftX(){
		target.Rotate (5,0,0);
	}
	public void rRightX(){
		target.Rotate (-5,0,0);
	}
	
	public void rLeftY(){
		target.Rotate (0,5,0);

	}
	public void rRightY(){
		target.Rotate (0,-5,0);
	}


	public void rLeftZ(){
		target.Rotate (0,0,5);
	}
	public void rRightZ(){
		target.Rotate (0,0,-5);
	}



	//Fonction de changement de taille, changer les bornes, voir les sliders
	//(voir windows => placement menu)
	void Update () {
		float v = sX.value;
		Vector3 courant = target.localScale;
		target.localScale = new Vector3 (courant.x, v, courant.z);

		v = sY.value;
		courant = target.localScale;
		target.localScale = new Vector3 (courant.x, courant.y, v);

		v = sZ.value;
		courant = target.localScale;
		target.localScale = new Vector3 (v, courant.y, courant.z);

		v = s.value;
		v /= 10.0f;
		courant = target.localScale;
		target.localScale = new Vector3 (courant.x*v, courant.y*v, courant.z*v);
			


}
}