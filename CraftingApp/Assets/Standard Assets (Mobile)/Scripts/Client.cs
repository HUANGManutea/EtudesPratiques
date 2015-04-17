using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System;

public class Client : MonoBehaviour {

	void Start(){
		TcpClient client = new TcpClient();
		IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);
		Debug.Log ("Connecting to 127.0.0.1 : 3000");
		client.Connect(serverEndPoint);
		
		NetworkStream clientStream = client.GetStream();
		Debug.Log ("Connected");
		string path = "C:/Users/Khayron/Documents/GitHub/EtudesPratiques/CraftingApp/Assets/Standard Assets (Mobile)/Prefabs/Cube.prefab";
		byte[] buffer = System.IO.File.ReadAllBytes(path);
		Debug.Log ("sending file.Length");
		clientStream.Write(buffer, 0 ,buffer.Length);
		clientStream.Flush();
		Debug.Log ("file sent");
	}


}
