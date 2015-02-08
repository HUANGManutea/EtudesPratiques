using UnityEngine;
using System.Collections;
public class NetworkManager : MonoBehaviour {
	
	public string ipAddress;
	public int port = 25565;
	public int nbClient = 2;
	public Transform spawnServer;
	
	//GUI
	void OnGUI(){
		if(GUI.Button(new Rect(250,130,125,25),"Créer un serveur")){
			Network.InitializeServer(nbClient,port,false);
		}
	}
	
	//messages
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
