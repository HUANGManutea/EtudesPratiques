using UnityEngine;
using System.Collections;

//à mettre sur une caméra en projection orthographique

public class FollowObject : MonoBehaviour {
	Transform target;
	public enum Direction {X,Y,Z};
	private Direction dir;
	private string name = "Exemple1";
	public Translate t;
	public GameObject destination;
	Renderer target2;
	
	void Start () {
		GameObject go = GameObject.Find (name);
		target = go.transform;
		target2 = go.renderer;
		dir = Direction.X;

	}
	
	public void setName(string s){
		name = s;
		t.setName (s);
		GameObject go = GameObject.Find (name);
		target = go.transform;
		target2 = go.renderer;
	}
	
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

	public void front(){
		camera.depth = 2;
		}
	public void back(){
		camera.depth = -2;
	}
	
	
	void Update () {
		
		switch(dir){
			
		case Direction.X:
			transform.rotation = Quaternion.LookRotation (target.right);
			transform.position = new Vector3 (target.position.x, target.position.y,target.position.z);
			
			for (int i =0; i<10; i++) {
				transform.Translate(Vector3.left, target);
			}
			break;
			
		case Direction.Y:
			transform.rotation = Quaternion.LookRotation (target.up);
			transform.position = new Vector3 (target.position.x, target.position.y,target.position.z);
			
			for (int i =0; i<10; i++) {
				transform.Translate(Vector3.down, target);
			}
			break;
			
		case Direction.Z:
			transform.rotation = Quaternion.LookRotation (target.forward);
			transform.position = new Vector3 (target.position.x, target.position.y,target.position.z);
			
			for (int i =0; i<10; i++) {
				transform.Translate(Vector3.back, target);
			}
			break;
		}
	}

	public void makeTran(){
				Renderer[] child = destination.GetComponentsInChildren<Renderer> ();
				foreach (Renderer o in child) {

						for (int j = 0; j < o.materials.Length; j++) {
				
								Color color = o.materials [j].color;
								color.a = 0.5f;
								o.materials [j].color = color;
						}
				}

				for (int j = 0; j < target2.materials.Length; j++)
				{
					
					Color color = target2.materials[j].color;
					color.a = 1f;
					target2.materials[j].color = color;
				}
			
		}

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
	
}
