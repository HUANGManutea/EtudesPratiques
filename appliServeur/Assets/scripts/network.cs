using UnityEngine;
using System.Collections;

public class network : MonoBehaviour {

	public int nbCo = 4;
	public int port = 25565;
	// Use this for initialization
	void Start () {
		Network.InitializeServer(nbCo,port,false);
	}

	void OnPlayerConnected(){
		Debug.Log("une personne s'est connectée");
	}
}
