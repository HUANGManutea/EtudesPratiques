using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public string ipAddress;
	public int port = 25565;
	public int nbClient = 2;
	public string objectview;

	// Use this for initialization
	void OnGUI(){
		GUI.Label(new Rect(5,100,200,20),"Adresse ip du serveur: ");
		ipAddress = GUI.TextField(new Rect(150,100,100,20),ipAddress);
		if(GUI.Button(new Rect(50,130,100,25),"Se connecter") && ipAddress.Length!=0){
			Network.Connect(ipAddress,port);
		}
		if(GUI.Button(new Rect(50,200,100,25),"exporter")){
			networkView.RPC("instantObject",RPCMode.Server);
			
		}
		if(GUI.Button(new Rect(250,130,125,25),"Créer un serveur")){
			Network.InitializeServer(nbClient,25565,false);
		}
	}

	[RPC]
	void instantObject(){
	}

	void OnPlayerConnected(){
		Debug.Log("client connecté");
	}
	void OnConnectedToServer(){
		Debug.Log("Connecté");
	}
	
	void OnFailedToConnect(){
		Debug.Log("Impossible de se connecter à: "+ ipAddress);
	}
	
	void OnServerInitialized(){
		Debug.Log("Serveur crée");
	}

}
