using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System;

/* 
 *
 */
public class Client : MonoBehaviour {
	public IPAddress ipserv;
	void Start(){
		TcpClient client = new TcpClient();
		try{
			if(!(ipserv = IPAddress.Parse(getIpInput.ip)).Equals(IPAddress.None)){
				IPEndPoint serverEndPoint = new IPEndPoint(ipserv, 80);
				Debug.Log ("Connecting to "+ipserv+"  : 80");
				client.Connect(serverEndPoint);
				
				NetworkStream clientStream = client.GetStream();
				Debug.Log ("Connected");
				string path = gameObjToPrefab.prefabPath;
				byte[] buffer = System.IO.File.ReadAllBytes(path);
				Debug.Log ("sending file.Length");
				clientStream.Write(buffer, 0 ,buffer.Length);
				clientStream.Flush();
				Debug.Log ("file sent");
			}
		}catch (FormatException f){
			Debug.Log("Ip format must be: XXX.XXX.XXX.XXX");
		}
	}


}
