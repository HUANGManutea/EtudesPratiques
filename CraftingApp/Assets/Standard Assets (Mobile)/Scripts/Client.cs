using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System;

/*this class manage the client side of the app*/
public class Client : MonoBehaviour {
	public IPAddress ipserv; 

	void Start(){
		//first, we are creating a TcpClient
		TcpClient client = new TcpClient();
		try{
			if(!(ipserv = IPAddress.Parse(getIpInput.ip)).Equals(IPAddress.None)){
				//the IPEndPoint is a network endpoint that the Tcpclient will connect to
				IPEndPoint serverEndPoint = new IPEndPoint(ipserv, 80);
				client.Connect(serverEndPoint);
				//to send data we need to create a networkstream
				NetworkStream clientStream = client.GetStream();
				//we need the path to the prefab file				
				string path = gameObjToPrefab.prefabPath;
				//to send the file, we need to put the file's data in a byte array buffer
				byte[] buffer = System.IO.File.ReadAllBytes(path);
				//writing the buffer in the NetworkStream
				clientStream.Write(buffer, 0 ,buffer.Length);
				//when it's done, we clean the NetworkStream
				clientStream.Flush();
			}
		}catch (FormatException f){
			//we can manage a bad IP format exception here
		}
	}


}
