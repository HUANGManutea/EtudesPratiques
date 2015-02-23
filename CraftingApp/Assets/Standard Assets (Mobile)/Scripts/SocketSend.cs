//
using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class SocketSend : MonoBehaviour
{
	public string IP = "192.168.1.10"; // default local
	public int port = 26000; 
	IPEndPoint remoteEndPoint;
	UdpClient client;
	string strMessage="";
	
	public void Start()
	{
		init();  
	}

	void OnGUI()
	{
		Rect rectObj=new Rect(40,120,200,400);
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.UpperLeft;
		GUI.Box(rectObj,"UDPSendData\n IP : "+IP+" Port : "+port,style);
		//
		strMessage=GUI.TextField(new Rect(40,160,140,40),strMessage);
		if (GUI.Button(new Rect(180,160,80,40),"Send"))
		{
			sendString(strMessage);
		}      
	}
	
	public void init()
	{
		remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, port);
		//remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
		//remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
		client = new UdpClient();
	}
	
	private void sendString(string message)
	{
		try
		{
			byte[] data = Encoding.UTF8.GetBytes(message);
			client.Send(data, data.Length, remoteEndPoint);
		}
		
		catch (Exception err)
		{
			print(err.ToString());
		}
	}
	
	void OnDisable()
	{
		if ( client!= null)   client.Close();
	}
}
