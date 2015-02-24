using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ConnectManager : MonoBehaviour {
	public string ip = "192.168.0.100";
	public int port = 25565;
	private bool affiche = false;
	public GameObject conmess;
	// Use this for initialization
	void Start () {
		Network.Connect(ip,port);
	}

	void Update(){
		if(affiche){
			conmess.SetActive(true);
			wait();
			affiche = false;
		}
	}

	IEnumerator wait(){
		yield return new WaitForSeconds(1);
	}

	void chgMess(string mess){
		conmess.GetComponent<Text>().text = mess;
	}
	void OnConnectedToServer(){
		chgMess("Connecté");
		affiche = true;
	}
	
	void OnFailedToConnect(){
		chgMess("Non Connecté");
		affiche = true;
	}
}
