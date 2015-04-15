using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {
	Transform target;
	public enum Direction {X,Y,Z};
	private Direction dir;
	private string name = "Exemple1";
	public Camera followObject;
	// Use this for initialization
	void Start () {
		//name = Extrude.name;
		target = GameObject.Find(name).transform;
		dir = Direction.X;
	}

	public void setName(string s){
		name = s;
		target = GameObject.Find(name).transform;

		}


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




	// Update is called once per frame
	void Update () {
	
	}
}
