using UnityEngine;
using System.Collections;

//à mettre sur une caméra en projection orthographique

public class FollowObject : MonoBehaviour {
	Transform target;
	public enum Direction {X,Y,Z};
	private Direction dir;
	private string name = "Exemple1";
	
	void Start () {
		target = GameObject.Find(name).transform;
		dir = Direction.X;
	}
	
	public void setName(string s){
		name = s;
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
}
