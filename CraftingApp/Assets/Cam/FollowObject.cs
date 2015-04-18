using UnityEngine;
using System.Collections;

//à mettre sur une caméra en projection orthographique

public class FollowObject : MonoBehaviour {
	//transform de l'objet à suivre
	Transform target;
	//renderer de l'objet à suivre
	Renderer target2;

	//enum des direction pour les switchs
	public enum Direction {X,Y,Z};

	//direction courante
	private Direction dir = Direction.X;

	//objet à déplacer
	private string name = "Exemple1";

	//objet englobant les objects crées
	public GameObject destination;
	
	//Objet translate
	//(ici Destionation aussi, c'est pour pouvoir appeler les fonctions)
	public Translate t;


	//fonction à supprimer au moment de la compilation(car exemple1 n'existera plus)
	void Start () {
		GameObject go = GameObject.Find (name);
		target = go.transform;
		target2 = go.renderer;
		dir = Direction.X;

	}

	//set la figure à suivre et initialise toutes les variables en rapport
	public void setName(string s){
		name = s;
		t.setName (s);
		GameObject go = GameObject.Find (name);
		target = go.transform;
		target2 = go.renderer;
	}

	//set la direction courante
	public void setDir(string s){
		switch (s[0]) {
		case 'X':
			dir = Direction.X;
			break;
		case 'Y':
			dir = Direction.Y;
			break;
		case 'Z':
			dir = Direction.Z;
			break;
		}
		
	}

	//met la camera en premier plan
	public void front(){
		camera.depth = 2;
		}

	//met la camera en arriere plan
	public void back(){
		camera.depth = -2;
	}


	//Rend tout les objets sauf celui suivi transparant
	public void makeTran(){
		//récupère les renderer de tout les objets présents
		Renderer[] child = destination.GetComponentsInChildren<Renderer> ();

		foreach (Renderer o in child) {
			for (int j = 0; j < o.materials.Length; j++) {
				
				Color color = o.materials [j].color;
				//valeur à modifier pour rendre plus ou moins transparant (0 : invisible, 1 : visible)
				color.a = 0.3f;
				o.materials [j].color = color;
			}
		}

		//rend l'objet suivi visible
		for (int j = 0; j < target2.materials.Length; j++)
		{
			Color color = target2.materials[j].color;
			color.a = 1f;
			target2.materials[j].color = color;
		}
		
	}


	//rend tout les objets visibles
	public void makeNorm(){
		Renderer[] child = destination.GetComponentsInChildren<Renderer> ();
		foreach (Renderer o in child) {
			
			for (int j = 0; j < o.materials.Length; j++) {
				
				Color color = o.materials [j].color;
				color.a = 1f;
				o.materials [j].color = color;
			}
		}
		
		
	}






	//place la camera selon un axe (dir) de l'objet à suivre et reste dessus continuellement
	void Update () {
		
		switch(dir){
			
		case Direction.X:
			//oriente la camera selon le bon axe (pas forcément la bon position)
			transform.rotation = Quaternion.LookRotation (target.right);

			//place la camera exactement sur l'object à suivre (toujours bien orienté)
			transform.position = new Vector3 (target.position.x, target.position.y,target.position.z);

			//recule la camera pour sotir de l'objet et le voir sur celle-ci (s'adapte à la taille d el'objet)
			for (int i =0; i<target.localScale.x/2; i++) {
				transform.Translate(Vector3.left, target);
			}
			break;
			
		case Direction.Y:
			transform.rotation = Quaternion.LookRotation (target.up);
			transform.position = new Vector3 (target.position.x, target.position.y,target.position.z);
			
			for (int i =0; i<target.localScale.y/2; i++) {
				transform.Translate(Vector3.down, target);
			}
			break;
			
		case Direction.Z:
			transform.rotation = Quaternion.LookRotation (target.forward);
			transform.position = new Vector3 (target.position.x, target.position.y,target.position.z);
			
			for (int i =0; i<target.localScale.z/2; i++) {
				transform.Translate(Vector3.back, target);
			}
			break;
		}
	}





}
