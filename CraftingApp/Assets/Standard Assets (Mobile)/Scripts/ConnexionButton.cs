using UnityEngine;
using System.Collections;

public class ConnexionButton : MonoBehaviour {
	private string ip="192.168.0.100";
	private int port = 25565;
	public GameObject connectSuccess;
	public GameObject connectError;
	// Use this for initialization
	void Start () {
		Network.Connect(ip,port);
	}
	void OnConnectedToServer(){
		connectSuccess.SetActive(true);
	}
	void OnFailedToConnect(){
		connectError.SetActive(true);
	}
}
