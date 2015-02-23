using UnityEngine;
using System.Collections;
using UnityEditor;
public class NetworkManager : MonoBehaviour {

	public string ipAddress;
	public int port = 25565;
	public int nbClient = 2;
	public Transform spawnServer;
	public GameObject objectPrefab;

	//GUI
	void OnGUI(){
		GUI.Label(new Rect(5,100,200,20),"Adresse ip du serveur: ");
		ipAddress = GUI.TextField(new Rect(150,100,100,20),ipAddress);

		if(GUI.Button(new Rect(50,130,100,25),"Se connecter") && ipAddress.Length!=0){
			Network.Connect(ipAddress,port);
		}
		if(GUI.Button(new Rect(50,200,100,25),"exporter")){
			//networkView.RPC("instantObject",RPCMode.Server);
			Network.Instantiate(objectPrefab,new Vector3(0,0,0),Quaternion.identity,0);
		}
		if(GUI.Button(new Rect(250,200,100,25),"package")){
			export();
		}
		if(GUI.Button(new Rect(50,250,100,25),"imp package")){
			import();
		}
		if(GUI.Button(new Rect(250,130,125,25),"Créer un serveur")){
			Network.InitializeServer(nbClient,25565,false);
		}
	}


	[RPC]
	void instantObject(){
		Instantiate(objectPrefab,new Vector3(0,0,0),Quaternion.identity);
<<<<<<< HEAD
	}

	void export(){
		AssetDatabase.ExportPackage("Assets/ActualDraw", "Entire Project.unitypackage",ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets|ExportPackageOptions.IncludeDependencies    );
	}

	void import(){
		AssetDatabase.ImportPackage("Entire Project",true);
=======
>>>>>>> origin/master
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
